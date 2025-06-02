
using UnityEngine;
using System.Threading.Tasks;
using System.Collections;

public class StoryItem : MonoBehaviour
{

    public GameObject storyCanvas; // Ссылка на Canvas с текстом
    //public TextMeshProUGUI storyTextUI; // Текстовый элемент UI
    public GameObject panel;



    public bool isShowing = false;

    public void ShowStory()
    {

        storyCanvas.transform.position =
               Camera.main.transform.position + Camera.main.transform.forward * 1.08f;
        storyCanvas.transform.rotation = Camera.main.transform.rotation;
        panel.SetActive(true);
        isShowing = true;

        hpBarUs.MentalHP += 50;

    }

    public void HideStory()
    {

        //storyCanvas.SetActive(false);
        //storyTextUI.gameObject.SetActive(false);
        panel.SetActive(false);
        isShowing = false;

    }

    void DelayedAction()
    {
        storyCanvas.transform.position =
               Camera.main.transform.position + Camera.main.transform.forward * 1.08f;
        storyCanvas.transform.rotation = Camera.main.transform.rotation;
        panel.SetActive(true);
        isShowing = true;

        hpBarUs.MentalHP += 50;
    }

}


