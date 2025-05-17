using UnityEngine;

public class menucontroller : MonoBehaviour
{
    [SerializeField] private GameObject panelHide;
    [SerializeField] private GameObject panelShow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SwitchPanel()
    {
        panelHide.SetActive(false); 
        panelShow.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }


}
