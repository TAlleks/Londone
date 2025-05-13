using TMPro;
using UnityEngine;

public class Tip : MonoBehaviour
{
    [SerializeField] TextMeshPro tip;
    [SerializeField] AnimatedHandOnInput animatedHandOnInput;
    private void OnTriggerStay(Collider other)
    {
        if (!(animatedHandOnInput.gripValue == 1)) tip.enabled = true;
        else tip.enabled = false;
    }
    private void OnTriggerExit(Collider other)
    {
        tip.enabled = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tip.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
