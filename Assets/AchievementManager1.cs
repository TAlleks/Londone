using UnityEngine;
using UnityEngine.UI;

public class AchievementManager1 : MonoBehaviour
{
    public static AchievementManager Instance;

    [SerializeField] public GameObject achievementPanel;
    [SerializeField] Collider achievementPanelCollider;
    
    public void UnlockAchievement(string achievementName)
    {
        if (achievementPanelCollider.CompareTag("Hands") == true)
        {
            achievementPanel.SetActive(true);
            Invoke("HideAchievement", 3f);
            Debug.Log($"Получено: {achievementName}");

        }

        
    }

    private void HideAchievement()
    {
        achievementPanel.SetActive(false);
    }
}