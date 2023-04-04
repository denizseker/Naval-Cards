using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    private Ship thisShip;
    private float speed = 0.05f;
    private Coroutine LookCoroutine;
    //Silahýn dönmeyi tamamalayýp tamamlamadýðý
    public bool isLooking = false;
   
    public void StartRotating()
    {
        if (LookCoroutine != null)
        {
            StopCoroutine(LookCoroutine);
        }
        LookCoroutine = StartCoroutine(LookAt());
    }

    private IEnumerator LookAt()
    {
        Quaternion lookRotation = Quaternion.LookRotation(thisShip.TargetShip.transform.position - transform.position);

        float time = 0;

        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, time);
            time += Time.deltaTime * speed;

            yield return null;

            if (transform.rotation == lookRotation)
            {
                isLooking = true;
                thisShip.Turn = false;
                break;
            }
        }
    }

    private void Start()
    {
        thisShip = GetComponentInParent<Ship>();
    }

}
