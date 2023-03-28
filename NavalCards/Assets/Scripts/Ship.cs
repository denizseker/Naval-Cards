using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ship : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject currentCell;
    public GameObject oldCell;
    public int health;

    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI upgradeText;
    [SerializeField] Animator upgradeTextAnim;
    [SerializeField] Material selectedMat;
    [SerializeField] Material normalMat;

    public GameObject TargetShip;
    private DragObject selecter;
    private LookAtObject lookScript;
    public bool isSelected;

    private void Awake()
    {
        currentCell = null;
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        if (gameObject.tag == "AllyShip")
        {
            gameManager.allyships.Add(gameObject);
        }
        if (gameObject.tag == "EnemyShip")
        {
            gameManager.enemyships.Add(gameObject);
        }
    }

    

    public void DuplicateUpgrade()
    {
        upgradeText.text = "Duplicate Upgrade";
        upgradeTextAnim.SetTrigger("DO");
        Instantiate(gameObject, transform.position, Quaternion.identity);
        //gameManager.SquareFormation();

    }
    public void HealthUpgrade()
    {
        IncreaseHealth(50);
        upgradeText.text = "Health Upgrade";
        upgradeTextAnim.SetTrigger("DO");
    }
    public void WeaponUpgrade()
    {
        upgradeText.text = "Weapon Upgrade";
        upgradeTextAnim.SetTrigger("DO");
    }

    public void IncreaseHealth(int _amount)
    {
        health += _amount;
        healthText.text = health.ToString();
    }
    public void ReduceHealth(int _amount)
    {
        health -= _amount;
        healthText.text = health.ToString();
    }

    public void DestroyShip()
    {
        if(gameObject.tag == "AllyShip")
        {
            gameManager.allyships.Remove(gameObject);
            Destroy(gameObject);
        }
        if (gameObject.tag == "EnemyShip")
        {
            gameManager.enemyships.Remove(gameObject);
            Destroy(gameObject);
        }
    }
    private void WhichUpgradeSelected()
    {
        //Sadece dost unitlere yapýlabilir upgradeler.
        if(gameObject.tag == "AllyShip")
        {
            if (selecter.upgradeIndex == 0)
            {
                HealthUpgrade();
            }
            if (selecter.upgradeIndex == 1)
            {
                WeaponUpgrade();
            }
            if (selecter.upgradeIndex == 2)
            {
                Debug.Log("Duplicate");
                DuplicateUpgrade();
            }
        }
    }

    public void SetTarget()
    {
        if(gameObject.tag == "AllyShip")
        {
            var randomNumber = Random.Range(0,gameManager.enemyships.Count);
            TargetShip = gameManager.GetComponent<GameManager>().enemyships[randomNumber];
        }
        if (gameObject.tag == "EnemyShip")
        {
            var randomNumber = Random.Range(0, gameManager.allyships.Count);
            TargetShip = gameManager.GetComponent<GameManager>().allyships[randomNumber];
        }
    }

    public void GetCell (GameObject _ship)
    {
        Debug.Log("Getcell içi1");
        for (int i = 0; i < gameManager.cells.Count; i++)
        {
            if (gameManager.cells[i].GetComponent<Cell>().isEmpty)
            {
                gameManager.cells[i].GetComponent<Cell>().GetShip(_ship);
                currentCell = gameManager.cells[i];
                Debug.Log("Getcell içi");
                return;
            }
        }

    }
    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (currentCell == null && gameObject.tag == "AllyShip")
        {
            GetCell(gameObject);
        }
        
    }


    void Start()
    {

        if(gameObject.tag == "AllyShip")
        {
            StartCoroutine(LateStart(0.1f));
        }
        
        selecter = GameObject.FindWithTag("Selecter").GetComponent<DragObject>();
        healthText.text = health.ToString();
        lookScript = GetComponentInChildren<LookAtObject>();
    }

    void Update()
    { 
        //Target seçili deðilse - oyun baþladýysa - 
        if(TargetShip == null && gameManager.isGameStarted)
        {
            SetTarget();
            lookScript.StartRotating();
        }


        //Upgrade'in gerçekleþtiði yer
        //Eðer obje seçilmiþ ise ancak selecter default pozisyona dönmüþse(sürükleme býrakýlmýþ)
        if (isSelected && selecter.transform.position.z == -33)
        {
            isSelected = false;
            WhichUpgradeSelected();
        }
    }

    //Main scriptin bulunduðu objede collider olmadýðý için fonksiyon üzerinden trigger kontrol ediyorum.
    public void ManuelTriggerEnter(Collider _other)
    {
        if (_other.tag == "EnemyBullet" && gameObject.tag == "AllyShip" || _other.tag == "AllyBullet" && gameObject.tag == "EnemyShip")
        {
            //Geminin canýný azaltýyoruz.
            ReduceHealth(_other.GetComponent<Bullet>().damage);

            //Geminin caný 0 veya küçük ise *Patlama Durumu
            if (health <= 0)
            {
                DestroyShip();
            }
            Destroy(_other.gameObject);
        }
    }
}
