using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LanguageText : MonoBehaviour
{
    private int language = 1;
    [Tooltip("0 - русский\n1 - английский")]
    public string[] text;
    private TextMeshProUGUI textLine;
    void Start()
    {
        language = PlayerPrefs.GetInt("language", language);
        textLine = GetComponent<TextMeshProUGUI>();
        textLine.text = "" + text[language];
    }

    private void Update()
    {
        if (language != PlayerPrefs.GetInt("language"))
        {
            language = PlayerPrefs.GetInt("language");
            textLine.text = "" + text[language];
        }
    }

}
