using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueGame : MonoBehaviour
{
    // Название сцены, которая загружается при продолжении
    public string savedSceneName = "GameScene"; // Или другое, в зависимости от вашей игры

    void Start()
    {
        // Проверяем, есть ли сохранение (если нет — кнопка неактивна)
        if (!PlayerPrefs.HasKey("SavedScene"))
        {
            GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
    }

    // Метод для загрузки сохранённой игры
    public void LoadSavedGame()
    {
        // Загружаем сцену из сохранения (если есть)
        if (PlayerPrefs.HasKey("SavedScene"))
        {
            string sceneToLoad = PlayerPrefs.GetString("SavedScene");
            SceneManager.LoadScene(sceneToLoad);

        }
        else
        {
            Debug.LogWarning("No saved game found!");
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       // FindObjectOfType<PlayerSaveSystem>().LoadSavedData();
    }

}
