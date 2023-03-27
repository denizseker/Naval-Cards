using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    public bool isEmpty;


    private void Start()
    {
        isEmpty = true;
        gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "AllyShip" && isEmpty && !Input.GetMouseButton(0))
        {
            Debug.Log("Girdi");
            other.transform.parent.transform.position = new Vector3(transform.position.x,other.transform.parent.transform.position.y,transform.position.z);
            isEmpty = false;
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "AllyShip" && Input.GetMouseButton(0))
        {
            isEmpty = true;
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }
}
