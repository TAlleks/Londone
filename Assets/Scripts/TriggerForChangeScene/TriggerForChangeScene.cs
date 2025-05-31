using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerForChangeScene : MonoBehaviour
{
    [SerializeField] private string sceneNameToLoad;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Hands"))
        {
            
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }
}
