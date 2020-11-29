using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField] private CinemachineFreeLook freeCameraHolder;
    [SerializeField] private float cameraRotationValue;

    // Update is called once per frame
    void Update()
    {
        freeCameraHolder.LookAt = CreatureManager.Instance.MasterCreature.transform;
        freeCameraHolder.Follow = CreatureManager.Instance.MasterCreature.transform;
        
        RotateCamera();
    }

    private void RotateCamera()
    {
        float rotateValue = InputTester.input_Instance.Inputs.Actions.RotateCamera.ReadValue<float>();
        if (rotateValue < 0)
        {
            freeCameraHolder.m_XAxis.Value += cameraRotationValue * Time.deltaTime;
        }
        else if(rotateValue > 0)
        {
            freeCameraHolder.m_XAxis.Value -= cameraRotationValue * Time.deltaTime;
        }
    }
}
