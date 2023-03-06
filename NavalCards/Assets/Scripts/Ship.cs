using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ship : MonoBehaviour
{

    public int health;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI upgradeText;
    [SerializeField] Animator upgradeTextAnim;
    [SerializeField] Material selectedMat;
    [SerializeField] Material normalMat;
    private DragObject selecter;

    private bool isSelected;

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

    //Selecter objeye girerse
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Selecter")
        {
            isSelected = true;
            gameObject.GetComponent<MeshRenderer>().material = selectedMat;
        }
    }

    //Selecter obje üstünden ayrýlýrsa
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Selecter")
        {
            isSelected = false;
            gameObject.GetComponent<MeshRenderer>().material = normalMat;
        }
    }
}
