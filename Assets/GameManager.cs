using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Настройки газет")]
    public int totalRegularNewspapers = 3;
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
        Debug.Log("test3");
        if (!specialNewspaperCollected)
        {
        Debug.Log("test4");
            specialNewspaperCollected = true;
            AchievementManager.Instance.UnlockAchievement("221B Baker Street");
        }
    }
}