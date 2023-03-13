using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ship : MonoBehaviour
{
    private GameObject gameManager;
    public int health;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI upgradeText;
    [SerializeField] Animator upgradeTextAnim;
    [SerializeField] Material selectedMat;
    [SerializeField] Material normalMat;


    public GameObject TargetShip;


    private DragObject selecter;
    public bool isSelected;


    private void Awake()
    {
        gameManager = GameObject.FindWithTag("GameManager");

        if(gameObject.tag == "AllyShip")
        {
            gameManager.GetComponent<GameManager>().allyships.Add(gameObject);
        }
        if (gameObject.tag == "EnemyShip")
        {
            gameManager.GetComponent<GameManager>().enemyships.Add(gameObject);
        }
    }

    public void DuplicateUpgrade()
    {
        upgradeText.text = "Duplicate Upgrade";
        upgradeTextAnim.SetTrigger("DO");
        Instantiate(gameObject, transform.position, Quaternion.identity);
        Instantiate(gameObject, transform.position, Quaternion.identity);
        Instantiate(gameObject, transform.position, Quaternion.identity);
        gameManager.GetComponent<GameManager>().SquareFormation();

    }
    public void HealthUpgrade()
    {
        health += 50;
        healthText.text = health.ToString();
        upgradeText.text = "Health Upgrade";
        upgradeTextAnim.SetTrigger("DO");
    }
    public void WeaponUpgrade()
    {
        upgradeText.text = "Weapon Upgrade";
        upgradeTextAnim.SetTrigger("DO");
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

    // Start is called before the first frame update
    void Start()
    {
        
        selecter = GameObject.FindWithTag("Selecter").GetComponent<DragObject>();
        healthText.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Upgrade'in gerçekleþtiði yer
        //Eðer obje seçilmiþ ise ancak selecter default pozisyona dönmüþse(sürükleme býrakýlmýþ)
        if (isSelected && selecter.transform.position.z == -33)
        {
            isSelected = false;
            WhichUpgradeSelected();
        }
    }
}
