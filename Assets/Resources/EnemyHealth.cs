using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] int maxHealth = 100;

    int currentHealth = 0;
    public int CurrentHitPoints {get { return currentHealth; }}

    public HealthBar healthBar;
    public GameObject canvasHealthBar;

    void OnEnable()
    {
        currentHealth = maxHealth;
    }

    void Start()
    {  
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage (int amount)
    {
        currentHealth -= Mathf.Abs(amount);
        anim.SetTrigger("Hurt");

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0 )
        {
            Die();
        }
    }
    void Die()
    {
        anim.SetBool("IsDead", true);
        Destroy(gameObject, 1f);
        Destroy(canvasHealthBar);
    }
}
