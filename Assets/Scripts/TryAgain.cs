using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgain : MonoBehaviour
{
    public string scene;

    public void LoadScene()
    {
        SceneManager.LoadScene(scene);
    }
}
