using UnityEngine;

public class HoldingCigerette : MonoBehaviour
{
    public GameObject cigarette; 

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    if (!isHolding)
        //    {

        //        cigarette.transform.SetParent(handHoldPoint);
        //        cigarette.transform.localPosition = Vector3.zero;
        //        cigarette.transform.localRotation = Quaternion.identity;
        //        isHolding = true;
        //    }
        //    else
        //    {

        //        cigarette.transform.SetParent(null);
        //        isHolding = false;


        //Rigidbody rb = cigarette.GetComponent<Rigidbody>();
        //if (rb != null)
        //{
        //    rb.AddForce(transform.forward * 5f, ForceMode.Impulse);
        //}
        //    }
        //}
    }

    void ThrowCigarette()
    {
        cigarette.transform.SetParent(null);
        Rigidbody rb = cigarette.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        if (rb != null)
        {
            rb.AddForce(transform.forward * 10f, ForceMode.Impulse);
        }
    }
}
