using UnityEngine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;

public class PlayerCombat : MonoBehaviour
{
    [Header("Dame Range")]
    public Transform attackPoint;
    public float attackRange = .5f;
    
    public LayerMask enemyLayers;
    public float attackRate = 2f;
    
    float nextAttackTime = 0f;
    [SerializeField] int combo = 1;
    [SerializeField] int comboNumber = 3;
    private float lastAttackTime = 0f; 
    private float comboResetTime = 1f; 
    [SerializeField] bool attacking; public bool Attacking { get { return attacking;}}  

    public Animator anim;
    Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        ComboAttack();
    }

    void ComboAttack()
    {
        if (GetComponent<PhotonView>().IsMine == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextAttackTime)
            {
                if (Time.time >= nextAttackTime)
                {
                    AttackNormal();
                    nextAttackTime = Time.time + 1f / attackRate;
                }

                // Tính knockback chỉ theo trục X
                Vector3 knockbackDir = transform.position;
                knockbackDir.y = 0;
                knockbackDir.z = 0;
                knockbackDir = knockbackDir.normalized;
                StartCoroutine(ComboDash(knockbackDir, 0.2f, .1f));
            }
            if (attacking && Time.time - lastAttackTime > .5f)
            {
                attacking = false;
            }
        }
    }

    void AttackNormal()
    {
        anim.SetTrigger("Attack_Normal");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {   
            enemy.GetComponent<PlayerHealth>().TakeDamage(30);
        }
    }

    IEnumerator ComboDash(Vector3 direction, float dashDistance, float dashTime)
    {
        float elapsed = 0f;
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + (player.isFacingRight ? Vector3.right : Vector3.left) * dashDistance;

        while (elapsed < dashTime)
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsed / dashTime);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);        
    }
}
