using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LouisClassicAttackSet : Implant
{
    public Animator animator;

    public bool isPlayer1;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask ennemyLayers;

    public float attackRate = 2f;
    private float nextAttackTime = 0f;

    private void Start()
    {
        attackPoint = this.GetComponent<PlayerController>().attackPoint;
    }

    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (isPlayer1)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Attack();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.RightControl))
                {
                    Attack();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
        }
    }

    void Attack()
    {
        // Joue l'animation
        animator.SetTrigger("ClassicAttack");

        // Détecte les ennemis 
        Collider2D[] hitEnnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, ennemyLayers);
        // Inglige les dégâts
        foreach(Collider2D ennemy in hitEnnemies)
        {
            ennemy.GetComponent<FightController>().TakeDamage(50);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
