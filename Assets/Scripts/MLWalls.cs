using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLWalls : MonoBehaviour
{
    public Material transparentBlueMaterial;
    public Material originalMaterial;
    public GameObject[] wallObjects; 
    private bool isTransparent = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) {
            ToggleTransparency();
        }
    }

    public void ToggleTransparency()
    {
        foreach (GameObject wallObject in wallObjects) 
        {
            if (isTransparent)
            {
                wallObject.GetComponent<Renderer>().material = originalMaterial;
            }
            else
            {
                wallObject.GetComponent<Renderer>().material = transparentBlueMaterial;
            }
        }
        isTransparent = !isTransparent; 
    }
}
