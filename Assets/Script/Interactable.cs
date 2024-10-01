using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string requiredItem; // Item needed to interact (e.g., "Key")
    public bool isLocked = true;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            Inventory playerInventory = other.GetComponent<Inventory>();

            if (isLocked && playerInventory.HasItem(requiredItem))
            {
                Debug.Log("Unlocked with " + requiredItem);
                Unlock(); // Unlock the door or perform the action
            }
            else if (isLocked)
            {
                Debug.Log("You need a " + requiredItem + " to interact.");
            }
            else
            {
                Interact(); // Interact if the object is unlocked
            }
        }
    }

    void Unlock()
    {
        isLocked = false;
        Debug.Log("Object unlocked.");
        // Perform unlock actions (e.g., open door, remove barrier, etc.)
    }

    void Interact()
    {
        Debug.Log("Interacted with the object.");
        // Perform actions for interacting with the object
    }
}
