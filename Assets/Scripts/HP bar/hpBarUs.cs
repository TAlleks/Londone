using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hpBarUs : MonoBehaviour
{
    [Header("Settings")]
    public Image fadePanel;          // Ссылка на UI Image (черная панель)
    public float minAlpha = 0f;      // Минимальная прозрачность (полностью прозрачно)
    public float maxAlpha = 1f;      // Максимальная прозрачность (полностью черный экран)
    public float fadeSpeed = 2f; // Скорость изменения

    private Color panelColor;

    [Header("Debug")]
    [Range(0f, 1f)] public float targetValue = 0f; // Текущее значение (0-1), которое управляет затемнением

    [SerializeField] public Image HpBar;
    [SerializeField] public Image HpBar_;

    public static float MentalHP = 100;
    public static float HP2 = 1;

    private void Start()
    {
        //MentalHP = PlayerPrefs.GetFloat("MentalHP");
        // Проверка компонентов
        if (fadePanel == null)
        {
            Debug.LogError("Не назначена панель для затемнения!");
            enabled = false;
            return;
        }

        panelColor = fadePanel.color;
        panelColor.a = minAlpha;
        fadePanel.color = panelColor;
    }
    public void Update()

    {
        MentalHP -= 0.01f * HP2;
        HpBar.fillAmount = MentalHP / 100f;

        float healthPercent = MentalHP / 100f;
        float targetAlpha = Mathf.Lerp(maxAlpha, minAlpha, healthPercent);

        // Плавное изменение
        panelColor.a = Mathf.MoveTowards(fadePanel.color.a, targetAlpha, fadeSpeed * Time.deltaTime);
        fadePanel.color = panelColor;

        Debug.Log(MentalHP);
        //PlayerPrefs.SetFloat("MentalHP", MentalHP);

        if (MentalHP <= 0)
        {
            SceneManager.LoadScene("Defeat");
        }


    }

}
