using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotate : MonoBehaviour
{

    public static CameraRotate cameraInstance;

    [SerializeField] private float cameraSpeed;

    [SerializeField] private float maxX;

    [SerializeField] private float minX;

    [SerializeField] private float actualX;
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
        if (InputTester.inputInstance._playerInputs.Actions.RotateCameraY.ReadValue<float>() != 0)
        {
            transform.RotateAround(transform.parent.position, Vector3.up,
                cameraSpeed * InputTester.inputInstance._playerInputs.Actions.RotateCameraY.ReadValue<float>() *
                Time.deltaTime);
        }

        if (InputTester.inputInstance._playerInputs.Actions.RotateCameraX.ReadValue<float>() != 0)
        {
            transform.RotateAround(transform.parent.position, transform.right,
                cameraSpeed * InputTester.inputInstance._playerInputs.Actions.RotateCameraX.ReadValue<float>() *
                Time.deltaTime);
            actualX += cameraSpeed * InputTester.inputInstance._playerInputs.Actions.RotateCameraX.ReadValue<float>() *
                       Time.deltaTime;
        }
    }
}
