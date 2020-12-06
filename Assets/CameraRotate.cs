using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{

    public static CameraRotate cameraInstance;
    public CinemachineFreeLook camera;

    [SerializeField] private float cameraSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        if (cameraInstance == null)
        {
            cameraInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (InputTester.inputInstance._playerInputs.Actions.RotateCamera.ReadValue<float>() != 0)
        {
            camera.m_XAxis.Value += InputTester.inputInstance._playerInputs.Actions.RotateCamera.ReadValue<float>() * cameraSpeed * Time.deltaTime;
        }
    }
}
