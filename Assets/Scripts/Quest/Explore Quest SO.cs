using UnityEngine;

[CreateAssetMenu(menuName = "Quests/Explore Quest")]
public class ExploreQuestSO : QuestScriptableObjects
{
    public override void OnProgress()
    {
        currentCount ++; // instant completion
    }
}
