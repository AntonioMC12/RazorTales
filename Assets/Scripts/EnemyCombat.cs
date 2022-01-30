using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public int AttackDamage = 20;
    public bool isAttacking = false;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamege(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        SoundManager.PlaySound("enemy_hurt");

        if (currentHealth <= 0)
        {
            Die();

        }
    }

    void Die()
    {
        animator.SetBool("IsDead", true);
        this.GetComponent<CapsuleCollider2D>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<EnemyAI>().enabled = false;
        this.enabled = false;
        Destroy(gameObject, 1.5f);
    }

    public void Attack(Collider2D player)
    {
        if (!isAttacking)
        {
            // Play an attack animation
            isAttacking = true;
            SoundManager.PlaySound("fire");

            //Deteck enemies in range of attack
            player.GetComponent<PlayerCombat>().TakeDamage(AttackDamage);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
