using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyData", menuName = "RPG 2D/EnemyData")]
public class EnemyData : ScriptableObject 
{
    public float Health;
    public float SpeedMove;
    public float enemyDamage;
}

