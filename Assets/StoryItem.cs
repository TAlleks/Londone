using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryItem : MonoBehaviour
{

    public GameObject storyCanvas; // Ссылка на Canvas с текстом
    //public TextMeshProUGUI storyTextUI; // Текстовый элемент UI
    public GameObject panel;

    private bool isShowing = false;

    public void ShowStory()
    {

        //storyCanvas.SetActive(true);
        //storyTextUI.gameObject.SetActive(true);
        storyCanvas.transform.position =
               Camera.main.transform.position + Camera.main.transform.forward * 1.08f;
        storyCanvas.transform.rotation = Camera.main.transform.rotation;
        panel.SetActive(true);
        isShowing = true;

    }

    public void HideStory()
    {

        //storyCanvas.SetActive(false);
        //storyTextUI.gameObject.SetActive(false);
        panel.SetActive(false);
        isShowing = false;

    }
}


