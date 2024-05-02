
using UnityEngine;

public class itemScript : MonoBehaviour
{   
    public int ID;
    public string itemName;
    public string Description;
    public string type;
    public Sprite icon;
    public int amount;

    [HideInInspector] public bool pickedUp;
}
