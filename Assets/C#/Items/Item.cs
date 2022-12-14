using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]

public class Item : ScriptableObject
{
    public int id;
    public int price;
    public string Name;
    public string description;
    public Sprite image;
    public int hpGiven;
}
