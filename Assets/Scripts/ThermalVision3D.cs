using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class ThermalVision3D : MonoBehaviour
{
    public Canvas thermalCanvas; // Assign this in the Inspector
    private ParticleSystem smokeParticleSystem;
    private ParticleSystem.MainModule smokeMain;

    private void Awake()
    {
        // Find the Particle System component on this GameObject or its children
        smokeParticleSystem = GetComponentInChildren<ParticleSystem>();
        if (smokeParticleSystem != null)
        {
            smokeMain = smokeParticleSystem.main;
        }
    }

    private void Start()
    {
        // Initially set the Canvas to not be visible
        if (thermalCanvas != null)
        {
            thermalCanvas.enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ToggleThermalVision();
        }
    }

    private void ToggleThermalVision()
    {
        if (thermalCanvas != null)
        {
            thermalCanvas.enabled = !thermalCanvas.enabled; // Toggle the thermal effect canvas
        }

        if (smokeParticleSystem == null) return; // Early exit if no Particle System is found

        if (thermalCanvas.enabled)
        {
            smokeMain.startColor = new ParticleSystem.MinMaxGradient(Color.red); // Change the smoke color to red
        }
        else
        {
            smokeMain.startColor = new ParticleSystem.MinMaxGradient(Color.white); // Change the smoke color back to white or its original color
        }
    }
}
