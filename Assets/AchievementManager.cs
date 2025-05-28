using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance;

    public GameObject achievementPanel;
    public TMP_Text achievementText;
    public float displayTime = 3f;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void UnlockAchievement(string name)
    {
        achievementText.text = name;
        achievementPanel.SetActive(true);
        Debug.Log("test1");
        // Для VR: позиционируем перед игроком
        if (Camera.main != null)
        {
        Debug.Log("test2");
            achievementPanel.transform.position =
                Camera.main.transform.position + Camera.main.transform.forward * 2f;
        }

        Invoke("HideAchievement", displayTime);
    }

    private void HideAchievement()
    {
        achievementPanel.SetActive(false);
    }
}