using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject delete;
    public void Start()
    {
        if (delete != null) delete.SetActive(false);   
    }
    public void StartButton()
    {
        SceneManager.LoadScene("Location");
    }

    public void ExitButton()
    {
        Application.Quit();
    } 
}
