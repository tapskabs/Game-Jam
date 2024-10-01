using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<string> items = new List<string>(); // Inventory list to store item names

    // Add an item to the inventory
    public void AddItem(string itemName)
    {
        if (!items.Contains(itemName))
        {
            items.Add(itemName);
            Debug.Log(itemName + " added to inventory.");
        }
        else
        {
            Debug.Log("Item already in inventory.");
        }
    }

    // Check if the inventory contains an item
    public bool HasItem(string itemName)
    {
        return items.Contains(itemName);
    }
}
