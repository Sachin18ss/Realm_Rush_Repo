using UnityEngine;

public class ExploreZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuestManager.Instance.ReportProgress<ExploreQuestSO>();
            gameObject.SetActive(false);
        }
    }
}
