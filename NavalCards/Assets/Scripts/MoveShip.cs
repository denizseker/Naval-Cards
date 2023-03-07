using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    private Vector3 targetpos;
    private bool Move = false;

    public void MoveToPos()
    {
        var step = 4 * Time.deltaTime;
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, targetpos, step);
    }
    private void Start()
    {
        targetpos = transform.parent.position + new Vector3(Random.Range(-1, -2f), 0, Random.Range(-1f, 2f));
        Move = true;
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
