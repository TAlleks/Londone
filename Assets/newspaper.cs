using UnityEngine;

public class Newspaper : MonoBehaviour
{
    [Header("Тип газеты")]
    public bool isSpecial = false;
    public void Collect()
    {
       
            if (isSpecial)
            {
                GameManager.Instance.CollectSpecialNewspaper();
            }
             GameManager.Instance.CollectRegularNewspaper();
           
            Destroy(gameObject);
        
    }
}