using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject shotPos;
    [SerializeField] GameObject bullet;

    private GameObject gameManager;
    private LookAtObject lookAtscr;

    private float uniqueTimer;

    private bool startShoot;
    private float timer;
    //S�lah�n ate� etme h�z� (x saniyede 1)
    private int fireRate = 2;

    // Start is called before the first frame update
    void Start()
    {
        uniqueTimer = Random.Range(0f, 1.5f);
        gameManager = GameObject.FindWithTag("GameManager");
        lookAtscr = GetComponent<LookAtObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //Oyun ba�lad�ysa silahlar�m�z ate� etmeye ba�l�yor.
        if (gameManager.GetComponent<GameManager>().isGameStarted && lookAtscr.isLooking)
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
                    var ins = Instantiate(bullet, shotPos.transform.position, Quaternion.identity);
                    ins.transform.parent = gameObject.transform;

                }
            }
            
        }
        
    }
}
