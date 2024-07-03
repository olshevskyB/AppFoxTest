using System.Text;

namespace AppFoxTest
{
    public class QuestHUDScreenPresenter : AbstractScreenPresenter<IQuestHUDScreenView, IQuestModel>, IQuestHUDScreenPresenter
    {
        private string _questText
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (AbstractQuest quest in _model.Quests)
                {
                    stringBuilder.AppendLine(quest.QuestDescription);
                }
                return stringBuilder.ToString();
            }
        }

        public QuestHUDScreenPresenter(IQuestHUDScreenView view, IQuestModel model) : base(view, model)
        {

        }

        public override void UpdateAllValues()
        {
            _view.UpdateQuestText(_questText);
        }

        public void UpdateQuestInfo()
        {
            _view.UpdateQuestText(_questText);
        }
    }
}
