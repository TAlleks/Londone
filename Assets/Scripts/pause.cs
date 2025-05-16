using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class pause : MonoBehaviour
{
    [SerializeField] private Button ButtonContinue;

    public GameObject pauseMenuCanvas;

    private bool isPaused = false;

    public InputActionProperty leftAButtonAction;

    void Awake()
    {
        ButtonContinue.onClick.AddListener(ResumeGame);
    }

    void Start()
    {
        pauseMenuCanvas.SetActive(false);
    }

    void Update()
    {
        if (leftAButtonAction.action.WasPressedThisFrame())
        {
            TogglePause();
        }
    }


    public void TogglePause()
    {

        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Останавливаем время в игре
        pauseMenuCanvas.SetActive(true);

    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Возобновляем время в игре
        pauseMenuCanvas.SetActive(false);

    }
}