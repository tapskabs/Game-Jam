using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<string> items = new List<string>();

    public void AddItem(string itemName)
    {
        items.Add(itemName);
        Debug.Log(itemName + " added to inventory.");
    }

    public void RemoveItem(string itemName)
    {
        if (items.Contains(itemName))
        {
            items.Remove(itemName);
            Debug.Log(itemName + " removed from inventory.");
        }
    }

    public bool HasItem(string itemName)
    {
        return items.Contains(itemName);
    }
}
