using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName; // Name of the item
    public Sprite itemIcon; // Icon of the item

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Item collected: " + itemName);
            other.GetComponent<Inventory>().AddItem(itemName, itemIcon); // Add the item and its icon to the player's inventory
            Destroy(gameObject); // Remove the item from the scene
        }
    }
}
