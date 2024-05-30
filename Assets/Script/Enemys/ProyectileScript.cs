using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private float timeSelfDestroy;
    private Transform target;

    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        ProyectileDirection();
    }

    private void ProyectileDirection()
    {
        Vector2 Direction = (target.transform.position-transform.position).normalized*speed;
        rb2d.velocity = new Vector2(Direction.x, Direction.y);
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
