using UnityEngine;

public class Newspaper : MonoBehaviour
{
    [Header("Тип газеты")]
    public bool isSpecial = false; // Отметьте в инспекторе для особой газеты

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isSpecial)
            {
                GameManager.Instance.CollectSpecialNewspaper();
            }
            else
            {
                GameManager.Instance.CollectRegularNewspaper();
            }
            Destroy(gameObject);
        }
    }
}