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
    private DragObject selecter;
    public bool isSelected;


    private void Awake()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        gameManager.GetComponent<GameManager>().ships.Add(gameObject);
    }

    public void DuplicateUpgrade()
    {
        upgradeText.text = "Duplicate Upgrade";
        upgradeTextAnim.SetTrigger("DO");
        GameObject obj1 = Instantiate(gameObject, transform.position, Quaternion.identity);
        GameObject obj2 = Instantiate(gameObject, transform.position, Quaternion.identity);
        GameObject obj3 = Instantiate(gameObject, transform.position, Quaternion.identity);
        //obj1.GetComponentInChildren<MoveShip>().enabled = true;
        //obj2.GetComponentInChildren<MoveShip>().enabled = true;
        //obj3.GetComponentInChildren<MoveShip>().enabled = true;
        //obj1.GetComponentInChildren<MoveShip>().targetpos = defaultTargetPos[0].transform.position;
        //obj2.GetComponentInChildren<MoveShip>().targetpos = defaultTargetPos[1].transform.position;
        //obj3.GetComponentInChildren<MoveShip>().targetpos = defaultTargetPos[2].transform.position;
        //obj1.GetComponent<MeshRenderer>().material = normalMat;
        //obj2.GetComponent<MeshRenderer>().material = normalMat;
        //obj3.GetComponent<MeshRenderer>().material = normalMat;
        //gameManager.GetComponent<GameManager>().ships.Add(gameObject);
        //gameManager.GetComponent<GameManager>().ships.Add(obj1);
        //gameManager.GetComponent<GameManager>().ships.Add(obj2);
        //gameManager.GetComponent<GameManager>().ships.Add(obj3);
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
        if(selecter.upgradeIndex == 0)
        {
            HealthUpgrade();
        }
        if(selecter.upgradeIndex == 1)
        {
            WeaponUpgrade();
        }
        if (selecter.upgradeIndex == 2)
        {
            Debug.Log("Duplicate");
            DuplicateUpgrade();
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
