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

    public static PlayerHealth instance;

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
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
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

        healthBar.SetHealth(currenthHealth);
    }

    public void TakeDamage(int damage)
    {
        if (!isInvicible)
        {
            currenthHealth -= damage;
            healthBar.SetHealth(currenthHealth);

            if (currenthHealth <= 0)
            {
                Die();
                return;
            }

            animator.Play("Hit");
            isInvicible = true;
            StartCoroutine(InvicibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());

        }

    }

    public void Die()
    {
        PlayerController.instance.enabled = false;
        GetComponent<PlayerAttack>().enabled = false;
        PlayerController.instance.Animation.SetTrigger("Die");
        PlayerController.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        GameOverManager.instance.OnPlayerDeath();
    }

    public void Respawn()
    {
        PlayerController.instance.enabled = true;
        GetComponent<PlayerAttack>().enabled = true;
        PlayerController.instance.Animation.SetTrigger("Respawn");
        PlayerController.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        currenthHealth = maxHealth;
        healthBar.SetHealth(currenthHealth);
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
