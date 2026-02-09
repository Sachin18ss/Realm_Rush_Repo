using TMPro;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    [System.Serializable]
    public class QuestUIBinding
    {
        public QuestScriptableObjects quest;
        public TextMeshProUGUI progressText;
    }

    public QuestUIBinding[] questBindings;

    private void OnEnable()
    {
        if (QuestManager.Instance != null)
            QuestManager.Instance.OnQuestUpdated += OnQuestUpdated;

        RefreshAll(); // initial UI fill
    }

    private void OnDisable()
    {
        if (QuestManager.Instance != null)
            QuestManager.Instance.OnQuestUpdated -= OnQuestUpdated;
    }

    void OnQuestUpdated(QuestScriptableObjects updatedQuest)
    {
        foreach (var binding in questBindings)
        {
            if (binding.quest == updatedQuest)
            {
                UpdateText(binding);
                break;
            }
        }
    }

    void RefreshAll()
    {
        foreach (var binding in questBindings)
        {
            UpdateText(binding);
        }
    }

    void UpdateText(QuestUIBinding binding)
    {
        binding.progressText.text =
            $"<size=128%><color=#36E141>{binding.quest.currentCount}</color></size>" +
        $"/{binding.quest.goalCount}";
    }
}
