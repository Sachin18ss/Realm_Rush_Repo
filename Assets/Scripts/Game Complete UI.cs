using TMPro;
using UnityEngine;

public class GameCompleteUI : MonoBehaviour
{
    public TextMeshProUGUI completeText;

    private void Start()
    {
        completeText.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (QuestManager.Instance != null)
            QuestManager.Instance.OnAllQuestsCompleted += OnGameCompleted;
    }

    private void OnDisable()
    {
        if (QuestManager.Instance != null)
            QuestManager.Instance.OnAllQuestsCompleted -= OnGameCompleted;
    }

    void OnGameCompleted()
    {
        completeText.gameObject.SetActive(true);
        //completeText.text = "ALL QUESTS COMPLETED!";
        Time.timeScale = 0f; 
    }
}
