using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasBar : MonoBehaviour
{   
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    
    public void SetMaxGas(int Gas) 
    { 
        slider.maxValue = Gas;
        slider.value = Gas;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetGas(int Gas) 
    {
        slider.value = Gas;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
