using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = .2f;
    public LayerMask enemyLayers;
    public static bool isAttacking = false;
    public int AttackDamage = 20;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth); 
    }

    // Update is called once per frame
    void Update()
    {
        //Attack
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                if (!isAttacking)
                {
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            Vector2 tapPoint;

                            // Update and Input function
                            tapPoint = touch.position;
                            tapPoint.y = Screen.height - tapPoint.y;
                            tapPoint.x = Screen.width - tapPoint.x;
                            if (tapPoint.x < 960)
                            {
                                Attack();
                            }
                            break;
                    }
                }
            }

        }
    }

    void Attack()
    {
        // Play an attack animation
        isAttacking = true;
        animator.SetTrigger("Attack");
        SoundManager.PlaySound("sword");

        //Deteck enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyCombat>().TakeDamege(AttackDamage);
        }

    }

    public void setIsAttackingFalse()
    {
        isAttacking = false;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHeatlth(currentHealth);
        animator.SetTrigger("Hurt");
        SoundManager.PlaySound("player_hurt");
        if (currentHealth <= 0)
        {
            Die();

        }
    }

    void Die()
    {
        animator.SetBool("IsDead", true);
        this.enabled = false;
    }

    public void loadGameOver(){
        SceneManager.LoadScene("GameOver");
    }
}
