using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject shotPos;
    [SerializeField] GameObject bullet;
    //S�lah�n ate� etme h�z� (x saniyede 1)
    [SerializeField] private float fireRate = 2;

    private GameObject gameManager;
    private LookAtObject lookAtscr;
    private Ship thisShip;

    private float uniqueTimer;

    private bool startShoot;
    private float timer;
    

    // Start is called before the first frame update
    void Start()
    {
        thisShip = GetComponentInParent<Ship>();
        uniqueTimer = Random.Range(1f, 3f);
        gameManager = GameObject.FindWithTag("GameManager");
        lookAtscr = GetComponent<LookAtObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //Oyun ba�lad�ysa silahlar�m�z ate� etmeye ba�l�yor.
        if (gameManager.GetComponent<GameManager>().isGameStarted && lookAtscr.isLooking && thisShip.TargetShip != null)
        {
            timer += Time.deltaTime;

            //Her silah�n ayn� anda ate�lememesi i�in
            if (uniqueTimer < timer)
            {
                startShoot = true;
            }

            if (startShoot)
            {
                if (timer > fireRate)
                {
                    timer = 0;
                    var ins = Instantiate(bullet, shotPos.transform.position, shotPos.transform.rotation);
                    ins.transform.parent = gameObject.transform;
                }
            }
        }
    }
}
