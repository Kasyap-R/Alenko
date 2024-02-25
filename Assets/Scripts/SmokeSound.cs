using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeSound : MonoBehaviour
{
    public ParticleSystem smokeEffect; // Assign in inspector
    private AudioSource audioSource; // Reference set in Start or Awake

    void Start()
    {
        // Find the AudioSource component on the child GameObject
        audioSource = GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        // Example toggle functionality on key press
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (smokeEffect.isPlaying)
            {
                smokeEffect.Stop();
                audioSource.Stop();
            }
            else
            {
                smokeEffect.Play();
                audioSource.Play();
            }
        }
    }
}
