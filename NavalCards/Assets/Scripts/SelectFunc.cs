using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFunc : MonoBehaviour
{

    private Ship shipScript;
    private MoveShip moveshipScript;

    // Start is called before the first frame update
    void Start()
    {
        shipScript = GetComponentInParent<Ship>();
        moveshipScript = GetComponentInParent<MoveShip>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
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
