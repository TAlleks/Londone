using UnityEngine;
using UnityEngine.UI;
public class DanageDetector : MonoBehaviour
{
    [SerializeField] public HPbar hpbar;
    public void OnDamageDetector(int damage)
    {
        hpbar.ChangeHP(-damage);

    }
}
