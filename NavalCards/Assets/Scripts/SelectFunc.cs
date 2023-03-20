using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFunc : MonoBehaviour
{

    private Ship shipScript;

    // Start is called before the first frame update
    void Start()
    {
        shipScript = GetComponentInParent<Ship>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Gemi ile etkileþime giren baþak colliderlar için ship scriptine etkileþim objesini gönderiyoruz.
        shipScript.ManuelTriggerEnter(other);


        if (other.tag == "Selecter")
        {
            shipScript.isSelected = true;
            //gameObject.GetComponent<MeshRenderer>().material = selectedMat;
        }
    }

    //Selecter obje üstünden ayrýlýrsa
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Selecter")
        {
            shipScript.isSelected = false;
            //gameObject.GetComponent<MeshRenderer>().material = normalMat;
        }
    }


}
