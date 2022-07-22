using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float ZoomOutFOV = 60f;
    [SerializeField] float ZoomInFOV = 20f;
    [SerializeField] float ZoomOutSens = 2f;
    [SerializeField] float ZoomInsens = 0.5f;
    bool ZoomedInToggle = false;
    [SerializeField] Canvas zoomIn;
    [SerializeField] Canvas zoomOut;

    [SerializeField] RigidbodyFirstPersonController fpscontroller;

    private void Start()
    {
        ZoomOut();
    }

    private void OnDisable()
    {
        ZoomOut();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if (ZoomedInToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomOut()
    {
        ZoomedInToggle = false;
        fpsCamera.fieldOfView = ZoomOutFOV;
        fpscontroller.mouseLook.XSensitivity = ZoomOutSens;
        fpscontroller.mouseLook.YSensitivity = ZoomOutSens;
        zoomOut.enabled = true;
        zoomIn.enabled = false;
    }

    private void ZoomIn()
    {
        ZoomedInToggle = true;
        fpsCamera.fieldOfView = ZoomInFOV;
        fpscontroller.mouseLook.XSensitivity = ZoomInsens;
        fpscontroller.mouseLook.YSensitivity = ZoomInsens;
        zoomIn.enabled = true;
        zoomOut.enabled = false;
    }
}
