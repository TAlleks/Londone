using UnityEngine;
using UnityEngine.UI;
public class newscriptforheal : MonoBehaviour
{
    [SerializeField] private GameObject tree;
    [SerializeField] private GameObject leaves;
    //[SerializeField] private Player player;

    private bool isFading = false;
    [SerializeField] public HPbar hpbar;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hands") && !isFading)
        {
            if (hpbar.HP < 100) 
            {
                hpbar.ChangeHP(20);

            }
            DestroyBush();
            isFading = true;

        }
    }

    void DestroyBush() 
    {
        if (tree != null) { Destroy(tree); }
        if (leaves != null) { Destroy(leaves); }

    }

}
