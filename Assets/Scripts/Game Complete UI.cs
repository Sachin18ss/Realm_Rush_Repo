using TMPro;
using UnityEngine;

public class GameCompleteUI : MonoBehaviour
{
    public TextMeshProUGUI completeText;

    private void Awake()
    {
        completeText.gameObject.SetActive(false);
    }

    private void Start()
    {
        
        if (QuestManager.Instance != null)
        {
            QuestManager.Instance.OnAllQuestsCompleted += OnGameCompleted;

            
            if (QuestManager.Instance.AreAllQuestsCompleted())
            {
                OnGameCompleted();
            }
        }
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
