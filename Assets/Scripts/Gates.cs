using UnityEngine;

public class Gates : MonoBehaviour
{
    [SerializeField] private Transform gate1;
    [SerializeField] private Transform gate2;
    public Vector3 targetPositionGate1;
    public Vector3 targetPositionGate2;
    public float speed = 1f;
    bool isOpenning = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpenning) 
        { 
            gate1.localPosition = Vector3.Lerp(gate1.localPosition, targetPositionGate1, speed * Time.deltaTime);
            gate2.localPosition = Vector3.Lerp(gate2.localPosition, targetPositionGate2, speed * Time.deltaTime);
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hands"))
        {
            isOpenning = true;
        }
    }
}
