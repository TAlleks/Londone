using UnityEngine;

public class CollectableNewspaper : MonoBehaviour
{
    public bool isSpecial = false; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hands")) 
        {
            if (isSpecial)
            {
                AchievementManager.Instance.UnlockAchievement("Бейкер-стрит, 221b");
            }
            else
            {
                GameManager.Instance.CollectRegularNewspaper();
            }
            Destroy(gameObject);
        }
    }
}