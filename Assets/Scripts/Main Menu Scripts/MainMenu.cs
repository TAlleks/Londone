using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    public void StartButton()
    {
        SceneManager.LoadScene("GameScenes");
    }

    public void ExitButton()
    {
        Application.Quit();
    } 
}
