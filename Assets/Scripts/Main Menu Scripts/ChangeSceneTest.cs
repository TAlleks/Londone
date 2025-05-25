using UnityEngine;
using UnityEngine.Rendering;

public class ChangeSceneTest : MonoBehaviour
{
    public Canvas MainMenu;
    public Canvas Setting;

    public void OnButtonPressed()
    {
        MainMenu.gameObject.SetActive(false);
        Setting.gameObject.SetActive(true);

    }
}
