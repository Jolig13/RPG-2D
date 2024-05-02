using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private GameObject handPrefab;
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private float attackDistance;
    [SerializeField] private float timeSpawnHand, timeZombieSpawn;
    private float countDownHand, countDownZombie;
    private Transform player;
    private Rigidbody2D rb;
    [SerializeField] private BossHealth bossHealth;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        countDownHand = timeSpawnHand;
        countDownZombie = timeZombieSpawn;
    }

    private void Update()
    {   
        countDownHand -= Time.deltaTime;
        countDownZombie -= Time.deltaTime;
        if (Vector2.Distance(player.position,rb.position) <= attackDistance && countDownHand <= 0f)
        {
            FirstAttack();
            countDownHand = timeSpawnHand;   
        }
        if (bossHealth.currentHealth <= 50 && countDownZombie <= 0f)
        {
            SecondAttack();
            countDownZombie = timeZombieSpawn;
        }
    }
    
    private void FirstAttack()
    {
        Instantiate(handPrefab,player.position,Quaternion.identity);
    }
    private void SecondAttack()
    {
        Instantiate(zombiePrefab,transform.position,Quaternion.identity);
    }
}
