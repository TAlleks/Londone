using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class PauseGame : MonoBehaviour
{

    public GameObject pauseMenuCanvas;
    public GameObject pausePanel;
    public GameObject settingsPanel;

    private bool isPaused = false;
    private bool wasPressed = false;
    private InputDevice leftController;


    void Start()
    {
        Time.timeScale = 1; // Возобновление

        isPaused = false;
        pauseMenuCanvas.SetActive(false);
    }

    void Update()
    {

        if (leftController == null || !leftController.isValid)
        {
            leftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
            return;
        }

        if (leftController.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPressed) || Input.GetKey("up")) 
        {
            // Срабатывает только при новом нажатии
            if ((isPressed || Input.GetKey("up")) && !wasPressed)
            {
                isPaused = !isPaused; // Переключаем состояние паузы

                if (isPaused)
                {
                    Time.timeScale = 0; // Пауза
                    pauseMenuCanvas.SetActive(true);
                    Debug.Log("Game Paused");
                }
                else
                {
                    Time.timeScale = 1; // Возобновление
                    pauseMenuCanvas.SetActive(false);
                    Debug.Log("Game Resumed");
                }
            }
            wasPressed = isPressed;
        }
    }

    public void ToSettings()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true);

    }

    public void ToExit()
    {
        
        SceneManager.LoadScene("Main Menu");
        int k = 1;
        if (k == 1) 
        {
            Time.timeScale = 1; // Возобновление

            isPaused = false;
            pausePanel.SetActive(false);
        }
        

    }


}
