using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    private GameObject target;
    private float speed = 0.05f;
    private GameManager gameManager;
    private Coroutine LookCoroutine;
    //Silah�n d�nmeyi tamamalay�p tamamlamad���
    public bool isLooking = false;
    //Update fonksiyonun 1 kere �al��mas� i�in
    private bool oneTime = false;
   
    private void StartRotating()
    {
        if (LookCoroutine != null)
        {
            StopCoroutine(LookCoroutine);
        }
        LookCoroutine = StartCoroutine(LookAt());
    }

    private IEnumerator LookAt()
    {
        Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - transform.position);

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
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Silahlar hedefe d�nd�r�l�yor. Oyun ba�lam��sa ve hen�z hedefe bakm�yorsa.
        if (gameManager.isGameStarted && !oneTime && !isLooking)
        {
            target = GetComponentInParent<Ship>().TargetShip;
            StartRotating();
            oneTime = true;
        }
    }
}
