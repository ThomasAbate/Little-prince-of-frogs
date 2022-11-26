using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 500;
    public int currenthHealth;

    public SpriteRenderer graphics;
    public BossHealthBar BosshealthBar;
    public Animator animator;

    public static BossHealth instance;

    private void Awake()
    {
        if (instance != null)
        {

            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la scène");
            return;
        }

        instance = this;
    }

    void Start()
    {
        currenthHealth = maxHealth;
        BosshealthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            TakeDamage(60);
        }

    }

    public void HealPlayer(int amount)
    {

        if ((currenthHealth + amount) > maxHealth)
        {
            currenthHealth = maxHealth;
        }
        else
        {
            currenthHealth += amount;
        }

        BosshealthBar.SetHealth(currenthHealth);
    }

    public void TakeDamage(int damage)
    {
            currenthHealth -= damage;
            BosshealthBar.SetHealth(currenthHealth);

            if (currenthHealth <= 0)
            {
                Die();
                return;
            }

    }

    public void Die()
    {

    }
}
