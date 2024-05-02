using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    [SerializeField] private int damageHand = 10;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        IReceiveDamage player = other.gameObject.GetComponent<IReceiveDamage>();
        if (player != null)
        {                
            player.ReceiveDamage(damageHand);
        } 
    }
}
