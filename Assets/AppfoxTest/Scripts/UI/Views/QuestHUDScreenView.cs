using TMPro;
using UnityEngine;

namespace AppFoxTest
{
    public class QuestHUDScreenView : AbstractScreenView, IQuestHUDScreenView
    {
        private IPresenter _presenter;

        [SerializeField]
        private TextMeshProUGUI _text;

        public override void Inject(DIContainer container)
        {
            base.Inject(container);
            IQuestModel model = container.GetSingle<ModelLocator>().GetModel<IQuestModel>();
            model.OnAddNewView(this);
        }

        public override void SetPresenter(IPresenter presenter)
        {
            _presenter = presenter;
        }

        public void UpdateQuestText(string text)
        {
            _text.text = text;
        }
    }
}
