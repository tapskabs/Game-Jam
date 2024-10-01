using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVInteract : MonoBehaviour
{
    public Camera loungeCamera;
    public Camera tvGameCamera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))  // "E" to interact
        {
            StartTVGame();
        }
    }

    void StartTVGame()
    {
        loungeCamera.enabled = false;
        tvGameCamera.enabled = true;
        // Add more logic for starting the TV game
    }
}
