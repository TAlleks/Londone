using UnityEngine;
using UnityEngine.XR;

public class PauseGame : MonoBehaviour
{

    public GameObject pauseMenuCanvas;

    private bool isPaused = false;
    private bool wasPressed = false;
    private InputDevice leftController;

    void Start()
    {
        pauseMenuCanvas.SetActive(false);
    }

    void Update()
    {

        if (leftController == null || !leftController.isValid)
        {
            leftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
            return;
        }

        if (leftController.TryGetFeatureValue(CommonUsages.menuButton, out bool isPressed))
        {
            // Срабатывает только при новом нажатии
            if (isPressed && !wasPressed)
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
}
