using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileHommingScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private float timeSelfDestroy;

    private Transform target;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update() 
    {
        ProyectileDirection();
    }

    private void ProyectileDirection()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
        Destroy(this.gameObject,timeSelfDestroy);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IReceiveDamage player = other.gameObject.GetComponent<IReceiveDamage>();
            if (player != null)
            {
                //Debug.Log("Cerebrooo");
                player.ReceiveDamage((int)enemyData.enemyDamage);
            }  

            Destroy(this.gameObject);
        }
    }
}
