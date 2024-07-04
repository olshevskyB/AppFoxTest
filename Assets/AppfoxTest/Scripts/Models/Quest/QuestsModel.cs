using System.Collections.Generic;
using System.Linq;

namespace AppFoxTest
{
    public class QuestsModel : IModel, IQuestModel
    {
        private IQuestHUDScreenPresenter _presenter;
        private List<AbstractQuest> _quests;

        private List<AbstractQuest> _uncompletedQuests;

        public IReadOnlyList<AbstractQuest> Quests => _uncompletedQuests;

        public QuestsModel(List<AbstractQuest> quests)
        {
            _quests = quests;
            AbstractQuest[] uncompletedQuests = new AbstractQuest[quests.Count];
            quests.CopyTo(uncompletedQuests);
            _uncompletedQuests = uncompletedQuests.ToList();
        }

        public void AddCompletedQuest(AbstractQuest quest)
        {
            _uncompletedQuests.Remove(quest);
            _presenter.UpdateQuestInfo();          
        }

        public void ProgressQuest()
        {
            _presenter.UpdateQuestInfo();
        }

        public void AddPresenter(IPresenter presenter)
        {
            if (presenter is IQuestHUDScreenPresenter questPresenter)
            {
                _presenter = questPresenter;
            }
        }

        public void AddView(IView view)
        {
            if (view is IQuestHUDScreenView questHUDView)
            {
                _presenter = new QuestHUDScreenPresenter(questHUDView, this);
            }
        }

        public void OnUnloadView(IView view)
        {
            if (view is IQuestHUDScreenView questHUDView)
            {
                _presenter = null;
            }
        }
    }
}
