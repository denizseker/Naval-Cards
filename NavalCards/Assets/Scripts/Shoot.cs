using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject shotPos;
    [SerializeField] GameObject bullet;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(bullet, shotPos.transform.position, Quaternion.identity);
        }
    }
}
