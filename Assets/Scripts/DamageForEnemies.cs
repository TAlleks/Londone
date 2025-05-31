using UnityEngine;

public class DamageForEnemies : MonoBehaviour
{
    [SerializeField] int damage;
    public bool isPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.TryGetComponent<DanageDetector>(out DanageDetector detector)) && (!isPlayer))
        {
            detector.OnDamageDetector(damage);
            GetComponent<Collider>().enabled = false;
        }
    }
}
