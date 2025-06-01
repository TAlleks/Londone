using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ChangeLanguage : MonoBehaviour
{
    public Text[] textElements;
    public string[] russianTexts;
    public string[] englishTexts;

    void Start()
    {
        PlayerPrefs.SetInt("language", 1);
        //LanguageText.language = PlayerPrefs.GetInt("language", 1);
        //ApplyLanguage();

    }

    public void RussianLanguage()
    {
        //LanguageText.language = 0;
        PlayerPrefs.SetInt("language", 0);
        //ApplyLanguage();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }
    public void EnglishLanguage()
    {
        //LanguageText.language = 1;
        PlayerPrefs.SetInt("language", 1);
        //ApplyLanguage();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    //private void ApplyLanguage()
    //{
    //    if (LanguageText.language == 0) // Русский
    //    {
    //        for (int i = 0; i < textElements.Length; i++)
    //        {
    //            if (i < russianTexts.Length && textElements[i] != null)
    //            {
    //                textElements[i].text = russianTexts[i];
    //            }
    //        }
    //    }
    //    else // Английский
    //    {
    //        for (int i = 0; i < textElements.Length; i++)
    //        {
    //            if (i < englishTexts.Length && textElements[i] != null)
    //            {
    //                textElements[i].text = englishTexts[i];
    //            }
    //        }
    //    }

    //}
}
