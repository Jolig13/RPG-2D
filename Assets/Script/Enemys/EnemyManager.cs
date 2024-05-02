using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager enemyManager;
    public int maxEnemies;
    [HideInInspector] public int currentEnemies = 0;
    [SerializeField] private GameObject bossPrefab;
    private bool spawnedBoss = false;
    private void Awake() 
    {
        if (enemyManager == null)
        {
            enemyManager = this;
        }   
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start() 
    {
        currentEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;    
    }
    private void Update() 
    {
        currentEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (currentEnemies <= 0 && spawnedBoss == false)
        {
            Instantiate(bossPrefab,transform.position,Quaternion.identity);
            spawnedBoss = true;
        }   
    }
    // private void OnDrawGizmos() 
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position,radius);   
    // }
}   
