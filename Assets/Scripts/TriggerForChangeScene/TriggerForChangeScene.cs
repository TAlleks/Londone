using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerForChangeScene : MonoBehaviour
{
    [SerializeField] private string sceneNameToLoad;
    public GameObject player;
    int k = 0;

    private void Start()
    {
        if (PlayerPrefs.GetInt("inchurch") == 1)
        {
            player.transform.position = new Vector3(-62.5f, 2.06f, -249f);
        }
        PlayerPrefs.SetInt("inchurch", 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Hands"))
        {
            PlayerPrefs.SetInt("inchurch", 1);

            SceneManager.LoadScene(sceneNameToLoad);
        }
    }
}
