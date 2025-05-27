using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance;

    public GameObject achievementPanel;
    public Text achievementText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void UnlockAchievement(string achievementName)
    {
        achievementText.text = achievementName;
        achievementPanel.SetActive(true);
        Invoke("HideAchievement", 3f);
        Debug.Log($"Получено: {achievementName}");
    }

    private void HideAchievement()
    {
        achievementPanel.SetActive(false);
    }
}