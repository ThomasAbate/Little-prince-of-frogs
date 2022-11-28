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
        Attack();
        HugeAttack();
    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            isAttacking = true;
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<BasicEnemy>().TakeDamage(Damage);
                Debug.Log("SHEEEEE");

            }

        }

    }
    
    void HugeAttack()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Animation.Play("Attack_3");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<BasicEnemy>().TakeDamage(HugeDamage);
                Debug.Log("SHEEEEE");
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
