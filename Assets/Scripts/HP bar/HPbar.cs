using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class HPbar : MonoBehaviour
{
    [SerializeField] public Image HpBar;
    [SerializeField] public Image HpBar_;
    [SerializeField] public Animator animatorDoctorWho;
    [SerializeField] public Collider collider;
    [SerializeField] public Collider collider_trigger;
    [SerializeField] public NavMeshAgent agent;

    public float HP = 100;

    public void ChangeHP(float amount)
    {
        HP += amount;
        HpBar.fillAmount = HP / 100;
        if (HP <= 0)
        {
            animatorDoctorWho.SetTrigger("Death");
            collider.enabled = false;
            agent.enabled = false;
            collider_trigger.enabled = false;
            HpBar_.enabled = false;
            

        }


    }

    

}
