using UnityEngine;

public class BarrilDestroy : MonoBehaviour, IReceiveDamage
{   
    [SerializeField] private GameObject[] potionPrefab;
    [SerializeField] private float Health = 20;
    [SerializeField] private float currentHealth;
    private Animator animator;
    private void Start() 
    {
        animator = GetComponent<Animator>();
        currentHealth = Health;
    }
    public void ReceiveDamage(int takeDamage)
    {
        currentHealth -= takeDamage;

        if (currentHealth <= 0)
        {
            currentHealth = 0; 
            DropPotion();  
            DestroyAnimation();     
        }
    }

    private void DropPotion()
    {   
        int index = Random.Range(0,potionPrefab.Length);
        Instantiate(potionPrefab[index],transform.position,Quaternion.identity);
    }
    private void DestroyAnimation()
    {
        animator.SetTrigger("Destroy");
        Destroy(gameObject,0.25f);
    }
}
