
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            IReceiveDamage enemy = other.GetComponent<IReceiveDamage>();
                if (enemy != null)
                    {
                           //Debug.Log("Enemigo Asesinado");
                           enemy.ReceiveDamage((int)playerData.damage);
                   }
        }
        if(other.gameObject.CompareTag("Boss"))
        {
            IReceiveDamage boss = other.GetComponent<IReceiveDamage>();
                if(boss != null)
                {
                    boss.ReceiveDamage((int)playerData.damage);
                }
        }    
        if (other.gameObject.CompareTag("Destructible"))
        {
            IReceiveDamage barril = other.GetComponent<IReceiveDamage>();
                if (barril != null )
                {
                    barril.ReceiveDamage((int)playerData.damage);
                }
        }
    }
}
