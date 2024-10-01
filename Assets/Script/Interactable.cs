using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string itemName;
    private Inventory inventory;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void Interact()
    {
        Debug.Log("Interacted with " + itemName);
        inventory.AddItem(itemName);
        Destroy(gameObject); // Pick up item and remove it from the scene
    }
}
