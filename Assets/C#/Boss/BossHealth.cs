using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int MaxHealth = 10;
    int currentHealth;
    public Animator animator;
    public BossHealth instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;


        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    public IEnumerator Die()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
        animator.Play("Dead");
        yield return new WaitForSeconds(2.30f);
        Destroy(gameObject);
    }
}
