using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMeleeScript : MonoBehaviour,IReceiveDamage
{   
    [SerializeField] private Transform target;
    [SerializeField] private float followDistance;
    [SerializeField] private float minChangeTime;
    [SerializeField] private float maxChangeTime;
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private Slider slider;
    private float timeChangeDirection;
    private bool followTarget = false;
    private Vector2 moveDirections;
    private Animator enemyAnim;
    private Rigidbody2D enemyRb;
    [SerializeField] private float currentHealth;
    private void Start() 
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        timeChangeDirection = Random.Range(minChangeTime,maxChangeTime);   
        target = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = enemyData.Health;
        slider.value = 1;
        GetRandomDirection();
    }

    private void Update()
    {
        Follow();
        MoveAnimation();
        if(target == null)
        {
            GetRandomDirection();
        }
    }

    private void Follow()
    {
    
        float playerDistance = Vector2.Distance(transform.position, target.position);

        if (playerDistance < followDistance)
        {
            followTarget = true;
        }
        else
        {
            followTarget = false;
        }

        if (followTarget)
        {
            moveDirections = (target.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(this.transform.position,target.position,enemyData.SpeedMove*Time.deltaTime);  
        }
        else
        {
            timeChangeDirection -= Time.deltaTime;

            if (timeChangeDirection <= 0)
            {
                GetRandomDirection();
                timeChangeDirection = Random.Range(minChangeTime,maxChangeTime);
            }
            enemyRb.MovePosition(enemyRb.position+moveDirections*enemyData.SpeedMove*Time.deltaTime);   
        }
    }

    private void GetRandomDirection()
    {
        float horizontal = Random.Range(-1f,1f);
        float vertical = Random.Range(-1f,1f);
        moveDirections = new Vector2(horizontal,vertical).normalized;   
    }

    // private void OnDrawGizmosSelected() 
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position,followDistance);
    // }

    private void MoveAnimation()
    {
        if(Mathf.Abs(moveDirections.x) > Mathf.Abs(moveDirections.y)) 
        {
            enemyAnim.SetFloat("Horizontal",Mathf.Sign(moveDirections.x));
            enemyAnim.SetFloat("Vertical",0);
        }
        else
        {
            enemyAnim.SetFloat("Horizontal",0);
            enemyAnim.SetFloat("Vertical",Mathf.Sign(moveDirections.y));
        }
    }

    public void ReceiveDamage(int takeDamage)
    {
        currentHealth -= takeDamage;
        slider.value = currentHealth/enemyData.Health;
        if (currentHealth <= 0)
        {
            slider.value = 0;
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IReceiveDamage player = other.gameObject.GetComponent<IReceiveDamage>();
            if (player != null)
            {
                //Debug.Log("Cerebrooo");
                player.ReceiveDamage((int)enemyData.enemyDamage);
            }
        }   
    }
}
