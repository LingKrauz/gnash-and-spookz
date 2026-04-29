using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//Made by Mitchell Kraus 12/2/21

public class CameraAxisOverride : MonoBehaviour
{
    public CinemachineFreeLook freeLookCam;

    AxisState xAxis;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            freeLookCam.m_XAxis.Value -= 30;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            freeLookCam.m_XAxis.Value += 30;
        }
        if (Input.GetAxisRaw("CamRotateX") > .01 || Input.GetAxisRaw("CamRotateX") < -0.01)
        {
            freeLookCam.m_XAxis.Value += (Input.GetAxisRaw("CamRotateX") * (Time.deltaTime * 1000));
        }
        if (Input.GetAxisRaw("CamRotateY") > .01 || Input.GetAxisRaw("CamRotateY") < -0.01)
        {
            freeLookCam.m_YAxis.Value += (Input.GetAxisRaw("CamRotateY") * (Time.deltaTime * 10));
        }
        recenterCam();
        //Cursor.visible = false;

    }
    void recenterCam()
    {
        if (Input.GetKey(KeyCode.R)) {

            if (!freeLookCam.m_RecenterToTargetHeading.m_enabled)
            {
                freeLookCam.m_RecenterToTargetHeading.m_enabled = true;
            }
        }
        else
        {
            freeLookCam.m_RecenterToTargetHeading.m_enabled = false;
        }
        
    }
}
