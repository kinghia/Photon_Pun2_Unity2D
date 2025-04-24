using UnityEngine;
using Photon.Pun;

public class PlayerCombat : MonoBehaviour
{
    [Header("Dame Range")]
    public Transform attackPoint;
    public float attackRange = .5f;
    
    public LayerMask enemyLayers;
    public float attackRate = 2f;
    
    float nextAttackTime = 0f;

    public Animator anim;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Time.time >= nextAttackTime)
            {
                AttackNormal();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    public void Down()
    {
        
    }

    void AttackNormal()
    {
        anim.SetTrigger("Attack_Normal");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            // todo
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);        
    }
}
