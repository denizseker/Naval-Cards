using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ship : MonoBehaviour
{

    public int health;
    [SerializeField] TextMeshProUGUI healthText;

    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health.ToString();
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Selecter")
        {
            if (!gameManager.isLeftClickOn)
            {
                Debug.Log("Upgrade");
                gameManager.isLeftClickOn = true;
            }

        }
    }
}
