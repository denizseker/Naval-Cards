using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject selecter;
    private Camera cam;

    public bool isLeftClickOn = false;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
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
                    Instantiate(selecter, hitPos, Quaternion.identity);
                }
            }

        }
    }


}
