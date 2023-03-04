using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ship : MonoBehaviour
{

    public int health;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] Material selectedMat;
    [SerializeField] Material normalMat;
    private GameManager gameManager;
    private GameObject selecter;
    

    bool isSelected;


    private void HealthUpgrade()
    {
        health += 50;
        healthText.text = health.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        healthText.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Upgrade'in ger�ekle�ti�i yer
        //E�er obje se�ilmi� ise ancak selecter kullan�m� b�rak�ld�ysa
        if (isSelected && selecter == null)
        {
            isSelected = false;
            HealthUpgrade();
            gameObject.GetComponent<MeshRenderer>().material = normalMat;
        }
    }

    //Selecter objeye girerse
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Selecter")
        {
            selecter = other.gameObject;
            isSelected = true;
            gameObject.GetComponent<MeshRenderer>().material = selectedMat;
        }
    }

    //Selecter obje �st�nden ayr�l�rsa
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Selecter")
        {
            isSelected = false;
            gameObject.GetComponent<MeshRenderer>().material = normalMat;
        }
    }
}
