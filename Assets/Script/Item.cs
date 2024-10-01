using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName; // Name of the item

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Item collected: " + itemName);
            other.GetComponent<Inventory>().AddItem(itemName); // Add the item to player's inventory
            Destroy(gameObject); // Remove the item from the scene
        }
    }
}
