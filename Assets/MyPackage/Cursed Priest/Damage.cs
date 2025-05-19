using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<DanageDetector>(out DanageDetector detector)) 
        {
            detector.OnDamageDetector(damage);
            GetComponent<Collider>().enabled = false;
        }
    }
}
