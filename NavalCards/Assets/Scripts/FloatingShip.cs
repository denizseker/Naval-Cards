using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingShip : MonoBehaviour
{
    private float intensity;
    private float speed;

    private void Start()
    {
        intensity = Random.Range(-1f, 1f);

        if (intensity < 0)
        {
            intensity -= 0.5f;
        }
        else
        {
            intensity += 0.5f;
        }

        speed = Random.Range(-2f, 2f);

        if (speed < 0)
        {
            speed -= 0.7f;
        }
        else
        {
            speed += 0.7f;
        }

    }
    private Quaternion FloatingRotation()
    {
        return Quaternion.Euler(
                    (intensity * Mathf.Sin(Time.time * speed)) * Time.deltaTime,
                    (intensity * Mathf.Sin(Time.time * speed)) * Time.deltaTime,
                    (intensity * Mathf.Sin(Time.time * speed)) * Time.deltaTime
                );
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = transform.rotation * FloatingRotation();
    }
}
