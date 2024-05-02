using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHandScript : MonoBehaviour
{
    [SerializeField] private float handDamage;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IReceiveDamage player = other.gameObject.GetComponent<IReceiveDamage>();
            if (player != null)
            {
                //Debug.Log("Cerebrooo");
                player.ReceiveDamage((int)handDamage);
                Destroy(this.gameObject);
            }
        }   
    }
    private void OnDestroy() 
    {
        Destroy(this.gameObject);   
    }
}
