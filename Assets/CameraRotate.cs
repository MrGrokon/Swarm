using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{

    public static CameraRotate cameraInstance;

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
            transform.RotateAround(transform.parent.position, Vector3.up, cameraSpeed * InputTester.inputInstance._playerInputs.Actions.RotateCamera.ReadValue<float>() * Time.deltaTime);
            print(InputTester.inputInstance._playerInputs.Actions.RotateCamera.ReadValue<float>());
        }
    }
}
