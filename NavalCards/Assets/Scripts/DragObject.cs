using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

    private GameManager gameManager;

    private bool checker;

    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        checker = false;
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

    //Mouse selecterin �zerindeyse
    void OnMouseOver()
    {
        //Sol click bas�l� ise
        if (Input.GetMouseButton(0))
        {
            gameManager.isLeftClickOn = true;
            gameObject.SetActive(true);
            float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
            transform.position = new Vector3(pos_move.x, transform.position.y, pos_move.z);
        }
        //Sol click bas�l� de�ilse/b�rak�ld�ysa
        else
        {
            if (!checker)
            {
                gameManager.isLeftClickOn = false;
                gameObject.GetComponent<LineRenderer>().enabled = false;
                Destroy(gameObject,0.1f);
                checker = true;
            }
        }

    }
}




