using UnityEngine;

[CreateAssetMenu(menuName = "Quests/Fetch Quest")]
public class FetchQuestSO : QuestScriptableObjects
{
    public override void OnProgress()
    {
        currentCount++;
    }
}
