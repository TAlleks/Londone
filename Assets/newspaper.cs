using JetBrains.Annotations;
using UnityEngine;

public class Newspaper : MonoBehaviour
{
    [Header("Тип газеты")]
    public bool isSpecial = false;

    StoryItem item;
    public void Start()
    {
        item = GetComponent<StoryItem>();
    }
    public void Collect()
    {
        while (item.isShowing) { }
        if (isSpecial)
            {
                
                GameManager.Instance.CollectSpecialNewspaper();
            }
             GameManager.Instance.CollectRegularNewspaper();
           
            Destroy(gameObject);
        
    }
}