using UnityEngine;

public class newscriptforheal : MonoBehaviour
{
    [SerializeField] private GameObject tree;
    [SerializeField] private GameObject leaves;
    [SerializeField] private Player player;

    private bool isFading = false;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hands") && !isFading)
        {
            if (player.HP < 100) 
            { 
                player.HP += 20;
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
