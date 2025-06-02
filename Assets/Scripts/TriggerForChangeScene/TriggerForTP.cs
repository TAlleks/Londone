using UnityEngine;

public class TriggerForTP : MonoBehaviour
{
    public Transform teleport;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hands"))
        {
            player.transform.position = teleport.position;
            
        }
    }
}
