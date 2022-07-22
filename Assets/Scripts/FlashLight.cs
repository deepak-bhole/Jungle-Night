using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{

    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 40f;

    Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();  
    }

    public void RetoreLightAngle(float RetoreAngle)
    {
        myLight.spotAngle = RetoreAngle;
    }
    public void AddLightIntensity(float IntensityAmount)
    {
        myLight.intensity += IntensityAmount;
    }




    private void DecreaseLightIntensity()
    {
        if(myLight.spotAngle <= minimumAngle)
        {
            return;
        }
        else
        {
            myLight.spotAngle -= angleDecay * Time.deltaTime;
        }
        
    }

    private void DecreaseLightAngle()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }
}
