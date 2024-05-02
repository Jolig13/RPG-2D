using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private int allSlots;
    [SerializeField] private int enableSlot;
    [SerializeField] private GameObject[] Slot;
    [SerializeField] private GameObject slotHolder;
    void Start()
    {
        allSlots = slotHolder.transform.childCount;
        Slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            Slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (Slot[i].GetComponent<SlotScript>().itemObject == null)
            {   
                Slot[i].GetComponent<SlotScript>().isEmpty = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag=="Consumable")
        {   
            //Debug.Log("Item Agarrado");
            GameObject itemPickUp = other.gameObject;

            itemScript itemScript = itemPickUp.GetComponent<itemScript>();

            AddItem(itemPickUp,itemScript.ID,itemScript.type,itemScript.Description,itemScript.icon);
        }   
    }

    private void AddItem(GameObject item, int ID, string itemType, string Description, Sprite iconItem)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if (Slot[i].GetComponent<SlotScript>().isEmpty)
            {
                item.GetComponent<itemScript>().pickedUp = true;

                Slot[i].GetComponent<SlotScript>().itemObject = item;
                Slot[i].GetComponent<SlotScript>().ID = ID;
                Slot[i].GetComponent<SlotScript>().type = itemType;
                Slot[i].GetComponent<SlotScript>().Description = Description;
                Slot[i].GetComponent<SlotScript>().icon = iconItem;

                item.transform.parent = Slot[i].transform;
                item.SetActive(false);

                Slot[i].GetComponent<SlotScript>().SlotUpdate();

                Slot[i].GetComponent<SlotScript>().isEmpty = false;
                return;
            }  
        }
         
    }
}
