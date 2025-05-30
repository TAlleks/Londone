using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class hpbarForUs : MonoBehaviour
{
    [SerializeField] public Image HpBar;
    [SerializeField] public Image HpBar_;

    public float HP = 100;

    public void ChangeHP(float amount)
    {
        HP += amount;
        HpBar.fillAmount = HP / 100;
        if (HP <= 0)
        {
            SceneManager.LoadScene("Defeat");

        }


    }


}
