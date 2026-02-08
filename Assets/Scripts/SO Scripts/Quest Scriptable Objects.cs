using UnityEngine;

public abstract class QuestScriptableObjects : ScriptableObject
{
    public string title;
    public string description;
    public int goalCount;
    //public int reward;

    [HideInInspector] public int currentCount;

    public bool IsCompleted => currentCount >= goalCount;

    public virtual void ResetQuest()
    {
        currentCount = 0;
    }

    public abstract void OnProgress();
}
