using UnityEngine;

public class EnemyMeleeAtack : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;

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
