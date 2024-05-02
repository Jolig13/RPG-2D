using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour
{
    public GameObject itemObject;
    public int ID;
    public string type;
    public string Description;
    public Sprite icon;

    public int amount;

    [HideInInspector] public bool isEmpty;

    public Transform slotChild;

    private void Start() 
    {
        slotChild = transform.GetChild(0);   
    }

    public void SlotUpdate()
    {
        slotChild.GetComponent<Image>().sprite = icon;
    }
}
