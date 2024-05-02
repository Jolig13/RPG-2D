using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyData", menuName = "RPG 2D/EnemyData")]
public class EnemyData : ScriptableObject 
{
    public GameObject EnemyPrefab;
    public float Health;
    public float currentHealth;
    public float SpeedMove;
    public float enemyDamage;
}

