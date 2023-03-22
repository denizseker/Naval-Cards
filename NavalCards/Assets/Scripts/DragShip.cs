using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragShip : MonoBehaviour
{
    private const float planeY = 0f;

    Plane plane = new Plane(Vector3.up, Vector3.up * planeY); // ground plane

    float rotSpeed = 50;

    private float holdTime = 1.5f; //or whatever
    private float acumTime = 0;

    private bool isRotating = false;


    void OnMouseDrag()
    {
        if(isRotating == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float distance; // the distance from the ray origin to the ray intersection of the plane
            if (plane.Raycast(ray, out distance))
            {
                transform.position = ray.GetPoint(distance); // distance along the ray
            }

            //if (Input.GetKey("e"))
            //{
            //    transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
            //}
            //if (Input.GetKey("q"))
            //{
            //    transform.RotateAround(transform.position, transform.up, Time.deltaTime * -90f);
            //}
        }
    }


    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("Touch");

            acumTime += Input.GetTouch(0).deltaTime;

            if (acumTime >= holdTime)
            {
                Debug.Log("Rotate baþladý");

                isRotating = true;
                float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
                float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
                transform.Rotate(Vector3.up, -rotX);
                transform.Rotate(Vector3.right, rotY);
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                isRotating = false;
                acumTime = 0;
            }
        }
    }
}
