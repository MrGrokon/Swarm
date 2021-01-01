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
    [SerializeField] private bool inversedControl = false;
    
    private int controlDirection = -1;
    private Vector3 rotation;

    [SerializeField] private GameObject Follow;
    [SerializeField] private Vector3 offset;
    private GameObject PlayerRef;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerRef = Objects.Instance.Alpha;
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
        transform.position = PlayerRef.transform.position + (PlayerRef.transform.right * offset.x) + PlayerRef.transform.up * offset.y + (-PlayerRef.transform.forward * offset.z);
        if (InputTester.inputInstance._playerInputs.Actions.RotateCameraY.ReadValue<float>() != 0)
        {
            PlayerRef.transform.eulerAngles += transform.up * cameraSpeed * InputTester.inputInstance._playerInputs.Actions.RotateCameraY.ReadValue<float>() * controlDirection *
                                               Time.deltaTime;
            transform.eulerAngles += transform.up * cameraSpeed * InputTester.inputInstance._playerInputs.Actions.RotateCameraY.ReadValue<float>() * controlDirection *
                                         Time.deltaTime;
        }

        if (InputTester.inputInstance._playerInputs.Actions.RotateCameraX.ReadValue<float>() != 0)
        {
            rotation += transform.right * InputTester.inputInstance._playerInputs.Actions.RotateCameraX.ReadValue<float>() * cameraSpeed * Time.deltaTime;
            rotation.x = Mathf.Clamp(rotation.x, minX, maxX);
        
            transform.localEulerAngles = new Vector3(rotation.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
        ManageControlDirection();
    }

    private void ManageControlDirection()
    {
        if (inversedControl)
        {
            controlDirection = 1;
        }
        else
        {
            controlDirection = -1;
        }
    }
}
