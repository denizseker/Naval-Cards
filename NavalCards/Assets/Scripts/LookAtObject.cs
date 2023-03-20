using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    private Ship thisShip;
    private float speed = 0.05f;
    private Coroutine LookCoroutine;
    //Silah�n d�nmeyi tamamalay�p tamamlamad���
    public bool isLooking = false;
    //Update fonksiyonun 1 kere �al��mas� i�in
    private bool oneTime = false;
   
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
                break;
            }
        }
    }

    private void Start()
    {
        thisShip = GetComponentInParent<Ship>();
    }

    // Update is called once per frame
    void Update()
    {
        //Silahlar hedefe d�nd�r�l�yor. Oyun ba�lam��sa ve hen�z hedefe bakm�yorsa.
        if (!oneTime && !isLooking)
        {
            //StartRotating();
            //oneTime = true;
        }
    }
}
