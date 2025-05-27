using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Настройки газет")]
    public int totalRegularNewspapers = 5;
    private int regularNewspapersCollected = 0;
    private bool specialNewspaperCollected = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectRegularNewspaper()
    {
        regularNewspapersCollected++;
        Debug.Log($"Обычных газет: {regularNewspapersCollected}/{totalRegularNewspapers}");

        if (regularNewspapersCollected >= totalRegularNewspapers)
        {
            AchievementManager.Instance.UnlockAchievement("Библиофил");
        }
    }

    public void CollectSpecialNewspaper()
    {
        if (!specialNewspaperCollected)
        {
            specialNewspaperCollected = true;
            AchievementManager.Instance.UnlockAchievement("Бейкер-стрит, 221b");
        }
    }
}