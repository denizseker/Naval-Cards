using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using TMPro;

//Eklenen kartýn upgrade özelliði inspector üzerinden dropdown listeden seçilmelidir.

public enum Upgrades
{
    Health, //index 0
    Weapon, //index 1
    Duplicate //index 2
};

public class Card : MonoBehaviour , IPointerDownHandler
{
    [SerializeField] TextMeshProUGUI CardTextObj;
    public string Text;
    private DragObject selecterScr;
    [SerializeField] Upgrades upgrades = new Upgrades();
    // Start is called before the first frame update
    void Start()
    {
        selecterScr = GameObject.FindWithTag("Selecter").GetComponent<DragObject>();
        CardTextObj.text = Text;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        selecterScr.upgradeIndex = ((int)upgrades);
        selecterScr.canMove = true;
    }

}
