using UnityEngine;

public class WeaponDamage : MonoBehaviour
{

    [SerializeField] public int damage = 10;
    [SerializeField] public bool isBullet = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.TryGetComponent<DanageDetector>(out DanageDetector detector))
            {
                detector.OnDamageDetector(damage);
                if(isBullet) { Destroy(gameObject); }
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.TryGetComponent<DanageDetector>(out DanageDetector detector))
            {
                detector.OnDamageDetector(damage);
                if (isBullet) { Destroy(gameObject); }
            }
        }
    }
}
