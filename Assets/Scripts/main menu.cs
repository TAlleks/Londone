using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Название сцены, которую нужно загрузить при нажатии на "New Game"
    public string newGameSceneName = "GameScene"; // Укажите имя вашей сцены

    // Метод, вызываемый при нажатии кнопки "New Game"
    public void NewGame()
    {
        // Очищаем сохранения (если нужно)
        PlayerPrefs.DeleteAll();

        // Загружаем новую сцену
        SceneManager.LoadScene(newGameSceneName);

        
    }

}