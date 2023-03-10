using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveShip : MonoBehaviour
{
    public Vector3 targetpos;
    public bool Move = false;

    public void MoveToPos()
    {
        Debug.Log("Girdi");
        var step = 4 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetpos, step);
    }
    private void Start()
    {
        //targetpos = transform.parent.position + new Vector3(Random.Range(1, -1f), 0, Random.Range(1, 1f));
        //Move = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Move)
        {
            MoveToPos();
        }

    }
}
