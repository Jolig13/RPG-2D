using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private GameObject WoodChop;
    private int minWood = 1;
    private int maxWood = 8;
    private float minPosx = -1.5f;
    private float maxPosx = 1.5f;

    // Update is called once per frame
    public void DamageReceive(float damage)
    {
        health -= damage;

        if (health <= 0 )
        {   
            DropWood();    
        }
    }
    private void DropWood()
    {
        int totalDrop = Random.Range(minWood,maxWood);
        for (int i = 0; i < totalDrop; i++)
        {   
            Vector3 randomPosition = new Vector3(Random.Range(minPosx,maxPosx),Random.Range(minPosx,maxPosx),0f);
            Instantiate(WoodChop,transform.position+randomPosition,Quaternion.identity);
          
        }
        Destroy(this.gameObject);
    }   
}
