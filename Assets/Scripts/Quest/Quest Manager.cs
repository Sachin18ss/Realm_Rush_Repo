using UnityEngine;
using System.Collections.Generic;
using System;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    public List<QuestScriptableObjects> activeQuests;

    
    public event Action<QuestScriptableObjects> OnQuestUpdated;
    public event Action OnAllQuestsCompleted;

    private void Awake()
    {
        Instance = this;

        foreach (var quest in activeQuests)
        {
            quest.ResetQuest(); 
        }
    }

    public void ReportProgress<T>() where T : QuestScriptableObjects
    {
        foreach (var quest in activeQuests)
        {
            quest.OnProgress();
            OnQuestUpdated?.Invoke(quest);

            //
            if (quest.IsCompleted)
            {
                CheckAllQuestsCompleted();
            }
        }
    }

    void CheckAllQuestsCompleted()
    {
        if (AreAllQuestsCompleted())
        {
            OnAllQuestsCompleted?.Invoke();
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
