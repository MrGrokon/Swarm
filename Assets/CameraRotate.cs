using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotate : MonoBehaviour {
    public CinemachineVirtualCamera camera;
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
    void Update() {
        var cameraAxisInput = InputTester.inputInstance._playerInputs.Actions.RotateCamera.ReadValue<Vector2>();
        if (cameraAxisInput.x != 0)
        {
            transform.RotateAround(transform.parent.position, Vector3.up, cameraSpeed * cameraAxisInput.x * Time.deltaTime);
            
//            print(cameraAxisInput.x);
        }

        if (Gamepad.current.rightStickButton.wasPressedThisFrame) {
            Debug.Log("fonctionne");
            var cinemachineComponent = this.camera.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
            cinemachineComponent.CameraSide = -cinemachineComponent.CameraSide;
        }
    }
}
