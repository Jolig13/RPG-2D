using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    //[SerializeField] private float spawnDelay = 1f;
    [SerializeField] private float spawnRadius;
    [SerializeField] private int maxEnemiesPerPoint =7;

    void Start()
    {
        Spawn();
    }

    private void Spawn()
    {   
        if (EnemyManager.enemyManager.currentEnemies >= EnemyManager.enemyManager.maxEnemies)
        {
            return;
        }
        int enemiesSpawn = Mathf.Min(maxEnemiesPerPoint,EnemyManager.enemyManager.maxEnemies-EnemyManager.enemyManager.currentEnemies);
        for (int i = 0; i < enemiesSpawn; i++)
        {
            Instantiate(enemyPrefab,transform.position,Quaternion.identity);
            EnemyManager.enemyManager.currentEnemies++;
        }
    }

    // private void OnDrawGizmos() 
    // {
    //     Gizmos.color = Color.cyan;
    //     Gizmos.DrawWireSphere(transform.position,spawnRadius);   
    // }
}
