using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Heal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Renderer renderer_tree;
    private Renderer renderer_leaves;
    private Color color_tree;
    private Color color_leaves;
    [SerializeField] private GameObject tree;
    [SerializeField] private GameObject leaves;
    [SerializeField] private Player player;
    private float alpha = 1f;

    private bool isFade = false;
    void Start()
    {
        renderer_tree = tree.GetComponent<Renderer>();
        renderer_leaves = leaves.GetComponent<Renderer>();
        color_tree = renderer_tree.material.color;
        color_leaves = renderer_leaves.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hands"))
        {

            Color _color_tree = color_tree;
            Color _color_leaves = color_leaves;
            if (alpha > 0)
            {
                alpha -= 0.004f;
                color_tree.a = alpha;
                color_leaves.a = alpha;

                if (player.HP < 100)
                {
                    player.HP += 0.4f;
                }
            }

            renderer_tree.material.color = _color_tree;
            renderer_leaves.material.color = _color_leaves;
        }
    }


    
}
