using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    private Camera cam;

    public bool canMove;
    private bool isInvisible;

    public int upgradeIndex = 0;

    private void Start()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        isInvisible = true;
        canMove = false;
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
        gameObject.SetActive(true);
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
        transform.position = new Vector3(pos_move.x, transform.position.y, pos_move.z);
    }

    //Selecter objesini görünmez yapar
    void DestroySelecter()
    {
        if (!isInvisible)
        {
            gameObject.GetComponent<LineRenderer>().enabled = false;
            isInvisible = true;
            //Objeyi uzak bir noktaya taþýyoruz.
            gameObject.transform.position = new Vector3(0, 0, -33);
        }
        
    }

    private void Update()
    {
        if (canMove)
        {
            //Objeyi point noktasýna getiriyoruz
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit Rayhit;

                if (Physics.Raycast(ray, out Rayhit))
                {
                    GameObject targethit = Rayhit.transform.gameObject;
                    Vector3 hitPos = Rayhit.point;
                    if (targethit != null)
                    {
                        hitPos = hitPos + new Vector3(0, 0.2f, 0);
                        gameObject.transform.position = hitPos;
                    }
                }

            }
            //Objenin hareketi fonksiyonu
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
            gameObject.GetComponent<LineRenderer>().enabled = true;
            isInvisible = false;
        }
    }

    private void OnMouseOver()
    {
        //Mouse objenin üstünde ama sol click basýlý deðil/býrakýldý
        if (!Input.GetMouseButton(0))
        {
            canMove = false;
        }
    }
}




