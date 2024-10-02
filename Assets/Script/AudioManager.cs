using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------Audio Source----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SPXSource;

    [Header("---------Audio Clip----------")]
    public AudioClip background;
    public AudioClip DoorOpening;
    public AudioClip FlickeringLights;
    public AudioClip FloorCreaking;
    public AudioClip FootSteps;
    public AudioClip Knock;
    public AudioClip SqueakyDoor;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SPXSource.PlayOneShot(clip);
    }
}

