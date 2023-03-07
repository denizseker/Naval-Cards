using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using TMPro;


public enum Upgrades
{
    Health,
    Weapon,
    Duplicate
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
