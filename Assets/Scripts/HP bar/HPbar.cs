using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class HPbar : MonoBehaviour
{
    [SerializeField] public Image HpBar;
    [SerializeField] public Image HpBar_;
    [SerializeField] public Animator animatorDoctorWho;
    [SerializeField] public Collider collider;
    [SerializeField] public Collider collider_trigger;
    [SerializeField] public NavMeshAgent agent;

    public bool isPlayer = false;

    public float HP = 100;

    public void ChangeHP(float amount)
    {
        HP += amount;
        HpBar.fillAmount = HP / 100;
        if (HP <= 0)
        {

            if (isPlayer)
            {
                SceneManager.LoadScene("Defeat");
            }
            else
            {
                animatorDoctorWho.SetTrigger("Death");
                collider.enabled = false;
                agent.enabled = false;
                if (collider_trigger != null)
                {
                    collider_trigger.enabled = false;
                }
                if (collider_trigger != null)
                {
                    HpBar_.enabled = false;
                }

                hpBarUs.MentalHP +=100;
            }

        }


    }

    

}
