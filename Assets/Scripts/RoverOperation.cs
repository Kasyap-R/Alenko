using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverOperation : MonoBehaviour
{
    public int maxBattery = 100; // Fixed: Added missing semicolon
    public int currentBattery;
    public int currentTemp;

    public BatteryBar batteryBar;
    public TempBar tempBar;
    public AudioSource smokeAudio;

    public Transform cameraTransform; // Assign your camera's transform in the inspector
    public Transform particleEffectTransform; // Assign your particle effect's transform in the inspector

    public int outsideTemp = 30;

    public int CalculateDistance()
    {
        float distance = Vector3.Distance(cameraTransform.position, particleEffectTransform.position);
        float normalizedDistance = (1f + Mathf.Exp(-(distance - 5)));
        return Mathf.RoundToInt(normalizedDistance);
    }


    // Start is called before the first frame update
    void Start()
    {
        currentBattery = maxBattery; // Fixed: Added missing semicolon
        batteryBar.SetMaxBattery(maxBattery);

        currentTemp = outsideTemp; // Cast to int if currentTemp is an int
        tempBar.SetTemp(outsideTemp);
        tempBar.SetMaxTemp(maxBattery);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            currentBattery -= 25;
            batteryBar.SetBattery(currentBattery);
        }

        if (!smokeAudio.isPlaying)
        { 
            currentTemp = 30;
        }
        else
        {
            int normalizedDistance = CalculateDistance();

            // Increase temperature based on distance, for example
            // You might need to adjust the scaling factor (e.g., 10 * normalizedDistance) based on your needs
            currentTemp = (outsideTemp + 5 * normalizedDistance); // Cast to int if currentTemp is an int
        }
        tempBar.SetTemp(currentTemp);
    }
}
