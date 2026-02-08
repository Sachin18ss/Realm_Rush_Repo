using UnityEngine;

[CreateAssetMenu(menuName = "Quests/Kill Quest")]
public class KillQuestSO : QuestScriptableObjects
{
    public override void OnProgress()
    {
        currentCount++;
    }
}
