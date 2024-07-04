using System.Collections.Generic;

namespace AppFoxTest
{
    public interface IQuestModel: IModel
    {
        public IReadOnlyList<AbstractQuest> Quests 
        { 
            get; 
        }

        public void AddCompletedQuest(AbstractQuest quest);

        public void ProgressQuest();
    }
}
