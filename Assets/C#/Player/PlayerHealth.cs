using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currenthHealth;

    public bool isInvicible = false;
    public float invincibilityFlashDelay = 0.3f;
    public float invincibilityFlashAfterHit = 3f;

    public SpriteRenderer graphics;
    public HealthBar healthBar;
    public Animator animator;

    void Start()
    {
        currenthHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }


        if (currenthHealth == 0)
        {
            animator.Play("Die");
        }
    }

    public void TakeDamage(int damage)
    {
        if(!isInvicible)
        {
            currenthHealth -= damage;
            healthBar.SetHealth(currenthHealth);
            animator.Play("Hit");
            isInvicible = true;
            StartCoroutine(InvicibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
            
        }
        
    }

    public IEnumerator InvicibilityFlash()
    {
        while (isInvicible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityFlashAfterHit);
        isInvicible = false;
    }
}
