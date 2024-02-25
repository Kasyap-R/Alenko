using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverOperation : MonoBehaviour
{  
    public int maxBattery = 100;
    public int maxGas = 100;
    public int maxTemp = 100;
    public int currentBattery;
    public int currentGas;
    public int currentTemp;

    public BatteryBar batteryBar;
    public GasBar gasBar;
    public TempBar tempBar;


    // Start is called before the first frame update
    void Start()
    {
        currentBattery = maxBattery;
        currentGas = maxGas;
        currentTemp = maxTemp;
        batteryBar.SetMaxBattery(maxBattery);
        gasBar.SetMaxGas(maxGas);
        tempBar.SetMaxTemp(maxTemp);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)){ 
            currentBattery -= 25;
            batteryBar.SetBattery(currentBattery);

            currentGas -= 25;
            gasBar.SetGas(currentGas);

            currentTemp -= 25;
            tempBar.SetTemp(currentTemp);
        }
    }
}
