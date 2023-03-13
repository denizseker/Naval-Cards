using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{

    private GameObject target;
    private float speed = 0.05f;

    private Coroutine LookCoroutine;
   
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
        }
    }


    void Start()
    {
        target = GameObject.FindWithTag("EnemyShip");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartRotating();
        }
    }
}
