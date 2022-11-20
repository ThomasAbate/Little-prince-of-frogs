using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SellButtonItem : MonoBehaviour
{
    public TMP_Text itemName;
    public TMP_Text itemPirce;
    public Image itemImage;

    public Item item;

    public void BuyItem()
    {
        Inventory inventory = GetComponent<Inventory>();
        
        if (inventory.coinsCount >= item.price)
        {
            inventory.content.Add(item);
            inventory.UpdateInventoryUI();
            inventory.coinsCount -= item.price;
            inventory.UpdateInventoryUI();
        }
    }
}
