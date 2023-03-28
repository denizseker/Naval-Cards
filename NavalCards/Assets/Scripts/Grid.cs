using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

    public Transform gridCellPrefab;

    [SerializeField] int height;
    [SerializeField] int width;

    private int offset_x = 0;
    private int offset_z = 0;

    // Start is called before the first frame update
    void Awake()
    {
        CreateGrid();
    }


    private void CreateGrid()
    {
        var name = 0;
        for (int i = 0; i < width; i++)
        {
            
            for (int j = 0; j < height; j++)
            {
                Vector3 worldPosition = new Vector3(i+offset_x-12, -0.55f, j+offset_z-3);
                Transform obj = Instantiate(gridCellPrefab, worldPosition, Quaternion.identity);
                obj.parent = gameObject.transform;
                obj.name = "Cell" + name;
                name++;
                offset_z += 7;
            }
            offset_x += 4;
            offset_z = 0;
        }
    }


}
