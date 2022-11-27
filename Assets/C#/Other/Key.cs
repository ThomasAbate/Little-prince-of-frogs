using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    public GameObject portal1, portal2;
    public GameObject NextLvl;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            portal1.SetActive(true);
            portal2.SetActive(true);
            NextLvl.SetActive(true);
            Destroy(gameObject);
        }
    }

}
