using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> allyships;
    public List<GameObject> enemyships;
    public List<GameObject> cells;

    public bool isGameStarted;

    public void SquareFormation()
    {
        float biggerX = 0;
        float currentX;
        float biggerZ = 0;
        float currentZ;

        // Set a targetposition variable of where to spawn objects.
        Vector3 targetpostion = new Vector3(0,5,-12);

        // Counter used for indexing when to start a new row.
        int counter = -1;
        // The offset of each object from one another on the X axis.
        int xoffset = -1;

        // Get the square root
        float sqrt = Mathf.Sqrt(allyships.Count) + 2;

        // Get the reference to the starting target positions x.
        float startx = targetpostion.x;

        // Loop through the number of objects to spawn for the square.
        for (int i = 0; i < allyships.Count; i++)
        {
            //ships[i].GetComponentInChildren<MoveShip>().ResetPos();
            // Increment the counter by 1.
            counter++;
            // Increment the xoffset by 1.
            xoffset++;

            /// We do this check because we do not want the offset being 1 on the 
            /// first iteration of the loop. We want the first index to be placed at 0.
            // If the xoffset > 1.
            if (xoffset > 1)
            {// Set the xoffset to 1.
                xoffset = 1;
            }

            // Set the targetposition to a new Vector 3 with the new variables and offset applied.
            targetpostion = new Vector3(targetpostion.x + (xoffset * 3f), allyships[i].transform.position.y, targetpostion.z);

            // If the counter is equal to the sqrt variable rounded down.
            if (counter == Mathf.Floor(sqrt))
            {// Reset counter to 0.
                counter = 0;
                // Set the targetposition x to the referenced start x.
                targetpostion.x = startx;
                // Set the targetposition y to 1 + 0.25f.
                // The 1 is to increment in the y axis, giving another row.
                // The 0.25f is to offset each sphere is the y axis so they do not overlap.
                targetpostion.z += 1 + 6f;
            }

            // Set the position of the instantiated object to the targetposition.
            allyships[i].GetComponent<MoveShip>().targetpos = targetpostion;

            currentX = targetpostion.x;
            currentZ = targetpostion.z;

            if (biggerX < currentX)
            {
                biggerX = currentX;
            }
            if(biggerZ < currentZ)
            {
                biggerZ = currentZ;
            }

            allyships[i].GetComponent<MoveShip>().Move = true;
        }

        for (int i = 0; i < allyships.Count; i++)
        {
            allyships[i].GetComponent<MoveShip>().targetpos -= new Vector3(biggerX / 2, 0, biggerZ / 2);
            allyships[i].GetComponent<MoveShip>().Move = true;
        }

    }

    //public void CalculateTarget()
    //{
    //    //4 Ally 3 enemy
    //    if (allyships.Count > enemyships.Count)
    //    {
    //        var j = 0;
    //        for (int i = 0; i < allyships.Count; i++)
    //        {
    //            if (j == enemyships.Count)
    //            {
    //                j = 0;
    //            }
    //            allyships[i].GetComponent<Ship>().TargetShip = enemyships[j];
    //            j++;
    //        }
    //    }
    //    //3 ally 3 enemy || 2 ally 3 enemy
    //    if (allyships.Count <= enemyships.Count)
    //    {
    //        for (int i = 0; i < allyships.Count; i++)
    //        {
    //            allyships[i].GetComponent<Ship>().TargetShip = enemyships[i];
    //        }
    //    }
    //}

    private void Start()
    {

    }


    public void Update()
    {

        //Round baþlat
        if (Input.GetKeyDown("space"))
        {
            isGameStarted = true;
            Debug.Log("Round baþladý");
        }
        //Round bitir
        if((enemyships.Count == 0 || allyships.Count == 0) && isGameStarted )
        {
            isGameStarted = false;
            Debug.Log("Round bitti");
        }
    }
}
