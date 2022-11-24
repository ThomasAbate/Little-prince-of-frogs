using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    private bool isInRange;

    private TMP_Text interactUI;

    public string ShopName;
    public Item[] itemsToSell;


    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("Interact UI").GetComponent<TMP_Text>();
        interactUI.enabled = false;
    }

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            ShopManager.instance.OpenShop(itemsToSell, ShopName);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isInRange = true;
            interactUI.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isInRange = false;
            interactUI.enabled = false;
            ShopManager.instance.CloseShop();
        }
    }
    
}
