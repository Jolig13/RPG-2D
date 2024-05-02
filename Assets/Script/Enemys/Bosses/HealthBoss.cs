using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour,IReceiveDamage
{
    public float Health;
    private Animator dieAnimation;
    public float currentHealth;
    [SerializeField] private Slider slider;
    [SerializeField] private Image bossHealth;

    private void Start()
    {
        dieAnimation = GetComponent<Animator>();
        currentHealth = Health;
        slider.value = 1;
    }

    public void ReceiveDamage(int damage)
    {
        currentHealth -= damage;
        slider.value = currentHealth/Health;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            slider.value = 0;
            Die();
        }
    }
    private void Die()
    {
        dieAnimation.SetTrigger("dieAnim");
        Destroy(gameObject,1f);
    }
}
