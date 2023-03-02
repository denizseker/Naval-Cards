using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject enemyShip;
    private Collider col;

    // Start is called before the first frame update
    void Start()
    {
        enemyShip = GameObject.Find("EnemyShip");
        col = GetComponent<BoxCollider>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EnemyShip")
        {
            Destroy(gameObject);
            other.GetComponent<Ship>().health -= 10;
        }
    }



    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position,enemyShip.transform.position, 15 * Time.deltaTime);
    }
}
