using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Transform teleportLocation; 

    void Start()
    {
        fadeManager = FindObjectOfType<FadeManager>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(fadeManager.FadeInAndOut(1f, other.gameObject, teleportLocation)); 
        }
    }
}

