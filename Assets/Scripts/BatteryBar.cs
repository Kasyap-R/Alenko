using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBar : MonoBehaviour
{   
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    
    public void SetMaxBattery(int charge) 
    { 
        slider.maxValue = charge;
        slider.value = charge;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetBattery(int charge) 
    {
        slider.value = charge;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
