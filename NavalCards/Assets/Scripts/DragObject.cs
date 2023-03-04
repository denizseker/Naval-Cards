using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

    private GameManager gameManager;

    private bool checker;
    private bool checker2;
    private bool checker3;

    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        checker = true;
        checker3 = false;
    }

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }


    //Selecter objesini hareket ettirir
    void MoveSelecter()
    {
        if (checker)
        {
            gameManager.canUpgrade = false;
            gameObject.SetActive(true);
            float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
            transform.position = new Vector3(pos_move.x, transform.position.y, pos_move.z);
        }
    }

    //Selecter objesini destroy eder
    void DestroySelecter()
    {
        if (checker3)
        {
            //obje mevcutsa
            if (gameObject != null)
            {
                gameManager.canUpgrade = true;
                checker = false;
                gameObject.GetComponent<LineRenderer>().enabled = false;
                Destroy(gameObject);
                checker3 = false;
            }
        }
        
    }

    private void Update()
    {
        //Sol click basýlý olmayýnca fonksiyonlarý durdurmasý için false deðer veriyoruz
        if (!Input.GetMouseButton(0))
        {
            checker2 = false;
            checker3 = true;
        }
        if (checker2)
        {
            MoveSelecter();
        }
        else
        {
            DestroySelecter();
        }
        
    }

    //Mouse objenin üstüne gelince
    private void OnMouseEnter()
    {
        //Mouse objenin üstünde ve sol click basýlýyken
        if (Input.GetMouseButton(0))
        {
            checker2 = true;
        }
        else
        {
            checker2 = false;
        }
    }
}




