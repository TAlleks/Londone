using UnityEngine;

public class DanageDetector : MonoBehaviour
{
    public void OnDamageDetector(int damage)
    {
        Player player = GetComponent<Player>();
        player.HP -= damage;
    }
}
