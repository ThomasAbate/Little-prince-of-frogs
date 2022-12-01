using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public int MaxHealth = 150;
    int currentHealth;
    public BossHealthBar bossHealthbar;
    public Animator animator;
    public BossHealth instance;
    public Animator fadeSystem;

    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
        instance = this;
    }

    void Start()
    {
        currentHealth = MaxHealth;
        bossHealthbar.SetMaxHealth(MaxHealth);
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        bossHealthbar.SetHealth(currentHealth);


        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    public IEnumerator Die()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
        animator.Play("Dead");
        yield return new WaitForSeconds(1.30f);
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1.30f);
        Destroy(gameObject);
        DontDestroyOnLoadScene.instance.RemoveFromDontDestoryOnLoad();
        SceneManager.LoadScene("The End");
        
        
    }
}
