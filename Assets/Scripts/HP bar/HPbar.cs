using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    [SerializeField] public Image HpBar;
    public float HP = 100;

    public void ChangeHP(float amount)
    {
        HP += amount;
        HpBar.fillAmount = HP / 100;

    }

}
