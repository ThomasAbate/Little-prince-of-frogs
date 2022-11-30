using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator Animation;
    public bool isAttacking = false;
    public static PlayerAttack instance;
    public Transform AttackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int Damage = 10;
    public int HugeDamage = 20;
    int hitCount =0;
    bool doubleAttack;

    private void Awake() 
    {
        instance = this;
    }

    void Start()
    {
        Animation = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
        HugeAttack();
    }

    void Attack()
    {
        if (!isAttacking)
        {
            hitCount = 0;
            isAttacking = true;
            Animation.Play("Attack_1");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.GetComponent<BasicEnemy>())
                {
                    enemy.GetComponent<BasicEnemy>().TakeDamage(Damage);
                    Debug.Log("SHEEEEE");
                }
                else if (enemy.GetComponent<BossHealth>())
                {
                    enemy.GetComponent<BossHealth>().TakeDamage(Damage);
                    Debug.Log("OUIIIII");
                }


            }
            hitCount++;
        }
        else if (hitCount == 1)
        {
            doubleAttack = true;
            Animation.SetBool("DoubleAttack", true);
            hitCount++;
        } 
        

    }

    public void EndAttack()
    {
        if (!doubleAttack)
        {
            hitCount = 0;
            isAttacking = false;
        }
    }

    public void EndDoubleAttack()
    {
        hitCount = 0;
        isAttacking = false;
        doubleAttack = false;
        Animation.SetBool("DoubleAttack", false);

    }

    void HugeAttack()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Animation.Play("Attack_3");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                if(enemy.GetComponent<BasicEnemy>())
                {
                    enemy.GetComponent<BasicEnemy>().TakeDamage(Damage);
                    Debug.Log("SHEEEEE");
                }
                else if(enemy.GetComponent<BossHealth>())
                {
                    enemy.GetComponent<BossHealth>().TakeDamage(Damage);
                    Debug.Log("OUIIIII");
                }
            }

        }

    }

    void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }

}
