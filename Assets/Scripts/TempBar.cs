using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempBar : MonoBehaviour
{   
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    
    public void SetMaxTemp(int temp) 
    { 
        slider.maxValue = temp;
        slider.value = temp;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetTemp(int temp) 
    {
        slider.value = temp;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
