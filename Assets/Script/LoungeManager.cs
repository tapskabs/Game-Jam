using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoungeManager : MonoBehaviour
{
    // 3D TV screen to display the 2D game
    [SerializeField] private GameObject tvScreen; // The TV object in your 3D scene
    private Camera gameCamera; // The camera rendering the 2D game
    [SerializeField] private Camera mainCamera;
    [SerializeField] private RenderTexture gameRenderTexture; // The render texture where the game will be displayed

    // 2D Game Scene to load (set it in the inspector)
    [SerializeField] private string gameSceneName = "2DGameScene";

    // Optionally, track the state of the 2D game (e.g., if it's running)
    private bool isGameRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the TV screen with the Render Texture
        InitializeTVScreen();

        // Start the 2D Game
        Start2DGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Initializes the TV screen by applying the Render Texture to it
    private void InitializeTVScreen()
    {
        if (tvScreen != null && gameRenderTexture != null)
        {
            // Get the Renderer component of the TV object
            Renderer tvRenderer = tvScreen.GetComponent<Renderer>();
            if (tvRenderer != null)
            {
                // Apply the Render Texture to the material of the TV screen
                Material tvMaterial = tvRenderer.material;
                if (tvMaterial != null)
                {
                    tvMaterial.mainTexture = gameRenderTexture;
                }
            }
        }
        else
        {
            Debug.LogError("TV screen or Render Texture not assigned.");
        }
    }

    // Starts the 2D game by loading the game scene
    private void Start2DGame()
    {
        if (!isGameRunning)
        {
            // Load the 2D Game Scene (make sure to add it to the build settings)
            SceneManager.LoadSceneAsync(gameSceneName, LoadSceneMode.Additive);
            isGameRunning = true;

            // Set up the camera to render to the Render Texture
            if (gameCamera != null && gameRenderTexture != null)
            {
                gameCamera.targetTexture = gameRenderTexture;
            }
            else
            {
                Debug.LogError("Game Camera or Render Texture not assigned.");
            }
        }
    }

    // Optionally, you can stop the game or switch back to the main scene
    public void Stop2DGame()
    {
        if (isGameRunning)
        {
            // Unload the 2D game scene
            SceneManager.UnloadSceneAsync(gameSceneName);
            isGameRunning = false;

            // Reset the camera's target texture
            if (gameCamera != null)
            {
                gameCamera.targetTexture = null;
            }
        }
    }

    private void OnSceneLoaded(AsyncOperation obj)
    {
        // Once the 2D scene is loaded, find the camera
        gameCamera = FindObjectOfType<Camera>();

        if (gameCamera != null)
        {
            // Set the 2D camera to render only to the Render Texture
            gameCamera.orthographic = true;  // Ensure it's orthographic for 2D rendering
            gameCamera.orthographicSize = 5; // Adjust this based on your needs
            gameCamera.clearFlags = CameraClearFlags.SolidColor; // Adjust the background
            gameCamera.backgroundColor = Color.black; // Set a background color if necessary

            // Ensure the 2D camera renders to the Render Texture
            gameCamera.targetTexture = gameRenderTexture;

            // Make sure the 2D camera does not render to the screen
            gameCamera.cullingMask = LayerMask.GetMask("Nothing"); // Assuming you don't want it rendering to anything on the screen

            Camera[] camerasInScene = FindObjectsOfType<Camera>();
            foreach (Camera cam in camerasInScene)
            {
                if (cam != gameCamera) // Disable all cameras except the intended 2D one
                {
                    cam.gameObject.SetActive(false);
                }
            }

        }

        // Assign the Render Texture to the TV screen material
        Renderer tvRenderer = tvScreen.GetComponent<Renderer>();
        if (tvRenderer != null && gameRenderTexture != null)
        {
            tvRenderer.material.mainTexture = gameRenderTexture;
        }

        // Set the 3D camera (player's view) to render the 3D world
        if (mainCamera != null)
        {
            // Set the main 3D camera to render normally
            mainCamera.clearFlags = CameraClearFlags.Skybox; // Or any appropriate background setting
            mainCamera.cullingMask = LayerMask.GetMask("Default"); // Render normal layers
        }
    }

        // Optional: If you want to trigger the 2D game dynamically (e.g., by a button press or event):
        public void ToggleGame()
    {
        if (isGameRunning)
        {
            Stop2DGame();
        }
        else
        {
            Start2DGame();
        }
    }
}
