using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

//following code is from Unity 2D Flickering Light (CODE PROVIDED) by ShadowLabz (https://www.youtube.com/watch?v=zfrpRYZfO1w)

public class FlickeringLights : MonoBehaviour
{
    [SerializeField] private Light2D light;

    private int frames = 0;

    private int framesPerRandomize = 30;    //will randomize ever 1/2 a second

    private float minValue = 0;    //min intensity value
    private float maxValue = 3;    //max intensity value


    //My own adjustments:
    private float flickerDuration; // How long the flickering lasts, is randomized
    [SerializeField] private float flickerChance = 0.005f;   // 0.5% chance to start flickering
    private float durationMin = 0.5f;
    private float durationMax = 2f;

    private bool isFlickering = false;
    private float flickerEndTime = 0;

    private System.Random random = new System.Random(); // Create an instance of the Random class


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        frames++;

        // Check if it's time to randomize (based on frame count)
        if (frames % framesPerRandomize == 0)
        {
            // If the light is flickering, handle flickering effect
            if (isFlickering)
            {
                if (Time.time > flickerEndTime)
                {
                    // End flickering
                    isFlickering = false;
                    light.intensity = maxValue; // Reset to steady max intensity
                }
                else
                {
                    // Continue flickering
                    RandomizeIntensity();
                }
            }
            else
            {
                // Randomly decide if flickering should start
                if (random.NextDouble() < flickerChance)
                {
                    StartFlickering();
                }
            }
        }
          
    }

    void StartFlickering()
    {
        flickerDuration = UnityEngine.Random.Range(durationMin, durationMax);

        isFlickering = true;
        flickerEndTime = Time.time + flickerDuration; // Set the end time for flickering
    }


    void RandomizeIntensity()
    {
        // Create an instance of the Random class
        System.Random random = new System.Random();

        float randomValue = (float)(random.NextDouble() * (maxValue - minValue) + minValue);
        light.intensity = randomValue;
    }
}
