using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragShip : MonoBehaviour
{

    private GameManager gameManager;
    private bool oneTime;
    private const float planeY = 0f;
    Plane plane = new Plane(Vector3.up, Vector3.up * planeY);
    public bool isDragging = false;

    private void Start()
    {
        gameManager = gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float distance; // the distance from the ray origin to the ray intersection of the plane
        if (plane.Raycast(ray, out distance))
        {
            transform.parent.transform.position = ray.GetPoint(distance); // distance along the ray
        }

        //Dragýn baþladýðýný belirtiyoruz
        if (!isDragging)
        {
            isDragging = true;
            oneTime = true;
        } 
    }
    private void OnMouseUp()
    {
        //Drag bitti
        isDragging = false;
        oneTime = true;
    }


    void ChangeVisual()
    {
        if (oneTime)
        {
            if (isDragging)
            {
                for (int i = 0; i < gameManager.cells.Count; i++)
                {
                    gameManager.cells[i].GetComponent<MeshRenderer>().enabled = true;
                    oneTime = false;
                }
            }
            else
            {
                for (int i = 0; i < gameManager.cells.Count; i++)
                {
                    //gameManager.cells[i].GetComponent<MeshRenderer>().enabled = false;
                    oneTime = false;
                }
            }
        }
        
    }


    private void Update()
    {
        ChangeVisual();
    }
}
