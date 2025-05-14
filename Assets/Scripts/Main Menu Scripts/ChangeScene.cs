using UnityEngine;
using UnityEngine.Rendering;

public class ChangeScene : MonoBehaviour
{
    public Canvas MainMenu;
    public Canvas Setting;

    public void OnButtonPressed()
    {
        MainMenu.gameObject.SetActive(false);
        Setting.gameObject.SetActive(true);

    }


}
