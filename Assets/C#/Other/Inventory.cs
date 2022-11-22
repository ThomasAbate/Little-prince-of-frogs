using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using static UnityEditor.Progress;
using TMPro;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public Text CoinsCountText;

    public List<Item> content = new List<Item> ();
    public int contentCurrentIndex = 0;
    public Image itemUI;
    public Sprite EmptyitemUI;
    public TMP_Text itemNameUI;

    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
        
            Debug. LogWarning("Il y a plus d'une instance de Inventory dans la scène");
            return;
        }
    
        instance = this;
    }

    private void Start()
    {
        UpdateInventoryUI();
    }

    public void ConsumeItem()
    {
        if(content.Count == 0)
        {
            return;
        }

        Item currentItem = content [contentCurrentIndex];
        PlayerHealth.instance.HealPlayer(currentItem.hpGiven);
        content.Remove(currentItem);
        GetNextItem();
        UpdateInventoryUI();
    }

    public void GetNextItem()
    {
        contentCurrentIndex++;

        if(contentCurrentIndex > content.Count -1)
        {
            contentCurrentIndex = 0;
        }

        UpdateInventoryUI();
    }

    public void GetPreviousItem()
    {
        if (content.Count == 0)
        {
            return;
        }

        contentCurrentIndex--;

        if (contentCurrentIndex < 0)
        {
            contentCurrentIndex = content.Count -1 ;
        }

        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        if (content.Count > 0)
        {
            itemUI.sprite = content[contentCurrentIndex].image;
            itemNameUI.text = content[contentCurrentIndex].name;
        }
        else
        {
            itemUI.sprite = EmptyitemUI;
            itemNameUI.text = "";
        }

        CoinsCountText.text = coinsCount.ToString();
    }

    public void AddCoins(int count)
    {
    coinsCount += count;
    CoinsCountText.text = coinsCount.ToString();
    }

    public void RemoveCoins(int count)
    {
        coinsCount -= count;
        CoinsCountText.text = coinsCount.ToString();
    }
}
