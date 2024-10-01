using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform teleportLocation; // Set this to the position where the player should be teleported

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected inside door trigger.");

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Teleport initiated.");
                Teleport(other.gameObject);
            }
        }
    }

    void Teleport(GameObject player)
    {
        if (teleportLocation != null)
        {
            player.transform.position = teleportLocation.position;
            Debug.Log("Player teleported to: " + teleportLocation.position);
        }
        else
        {
            Debug.LogWarning("Teleport location is not set!");
        }
    }
}
