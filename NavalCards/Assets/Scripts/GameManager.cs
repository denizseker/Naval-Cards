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



    private void Start()
    {
        for (int i = 0; i < allyships.Count; i++)
        {
            cells[i].GetComponent<Cell>().GetShip(allyships[i]);
            allyships[i].GetComponent<Ship>().currentCell = cells[i];
        }
    }


    public void Update()
    {
        //Round baþlat
        if (Input.GetKeyDown("space"))
        {
            isGameStarted = true;
            for (int i = 0; i < cells.Count; i++)
            {
                cells[i].GetComponent<MeshRenderer>().enabled = false;
            }
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
