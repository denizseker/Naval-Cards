using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    public bool isEmpty;
    private GameManager gameManager;
    private GameObject currentShip;

    public Material EmptyMat;
    public Material FullMat;

    private bool oneTime;

    private void Awake()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        gameManager.cells.Add(gameObject);
        isEmpty = true;
        gameObject.GetComponent<MeshRenderer>().material = EmptyMat;
    }

    
    public void GetShip(GameObject _ship)
    {
        currentShip = _ship;
        isEmpty = false;
        currentShip.transform.position = new Vector3(transform.position.x, currentShip.transform.position.y, transform.position.z);
        gameObject.GetComponent<MeshRenderer>().material = FullMat;
    }

    private bool isShipOn()
    {
        if(currentShip != null)
        {
            if (currentShip.transform.position == new Vector3(transform.position.x, currentShip.transform.position.y, transform.position.z))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
        
    }

    private void Update()
    {
        //Stayden çýkýnca 1 kere daha kontrol etmesi için
        if (oneTime)
        {
            //Sürekli kontrol ediyor eðer gemi halen sürükleniyor ise
            if (!isShipOn())
            {
                gameObject.GetComponent<MeshRenderer>().material = EmptyMat;
                isEmpty = true;
                currentShip = null;
            }
        }
        oneTime = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "AllyShip")
        {
            //Gemi üstündeyse ve currentship null ise
            if (!other.GetComponentInParent<DragShip>().isDragging && currentShip == null)
            {
                other.transform.parent.transform.position = new Vector3(transform.position.x, other.transform.parent.transform.position.y, transform.position.z);
                currentShip = other.transform.parent.gameObject;
                currentShip.GetComponent<Ship>().currentCell = gameObject;
                isEmpty = false;
                gameObject.GetComponent<MeshRenderer>().material = FullMat;
            }
            //Eðer cell dolu ise yeni sürüklenen gemiyi eski celline geri gönderiyorum
            if(currentShip != null && !isEmpty)
            {
                if(!Input.GetMouseButton(0) && other.transform.parent.transform.position != new Vector3(transform.position.x, other.transform.parent.transform.position.y, transform.position.z))
                {
                    other.transform.parent.transform.position = other.GetComponentInParent<Ship>().currentCell.transform.position;
                }
            }
                
            oneTime = true;
        }
    }
}
