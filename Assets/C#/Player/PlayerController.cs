using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public bool jump;
    public SpriteRenderer Player;
    public bool isOnGound = true;
    public float JumpForce;

    public Animator Animation;
    public Rigidbody2D rb;
    public Collider2D playerCollider;
    
    public static PlayerController instance;


    public AudioClip audioClip;
    private AudioSource audioSource;

    public LayerMask GroundlayerMask;

    private void Awake() 
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.D))
        {
            speed = 2.5f;
            Player.flipX = false;
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            Animation.SetFloat("Speed", 2);
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 4f;
                Player.flipX = false;
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                Animation.SetFloat("Speed", 5);
            }
        }

        //Q ne marche pas du coup j'ai du mettre A
        else if (Input.GetKey(KeyCode.A))
        {
            speed = 2.5f;
            Player.flipX = true;
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            Animation.SetFloat("Speed",2);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 4f;
                Player.flipX = true;
                transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
                Animation.SetFloat("Speed", 5);

            }
        }
        else
        {
            Animation.SetFloat("Speed", 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGound)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode2D.Impulse);
            isOnGound = false;
            Animation.SetFloat("IsJumping", 1);
        }
        
        else if (Input.GetKeyDown(KeyCode.Space) && isOnGound)
        {
            Animation.SetFloat("IsJumping", 0);
        }

        if(!isOnGound)
        {
            Animation.SetFloat("IsJumping", 2);
        }

            
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGound = true;
            Animation.SetFloat("IsJumping", 0);
        }

    }


    public void SwordSwing()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}

