using UnityEngine;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    public List<QuestScriptableObjects> activeQuests;

    private void Awake()
    {
        Instance = this;

        foreach (var quest in activeQuests)
            quest.ResetQuest();
    }

    public void ReportProgress<T>() where T : QuestScriptableObjects
    {
        foreach (var quest in activeQuests)
        {
            if (quest is T && !quest.IsCompleted)
            {
                quest.OnProgress();
            }
        }
    }

    public bool AreAllQuestsCompleted()
    {
        foreach (var quest in activeQuests)
        {
            if (!quest.IsCompleted)
                return false;
        }
        return true;
    }
}
