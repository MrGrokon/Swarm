using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotate : MonoBehaviour
{

    public static CameraRotate cameraInstance;

    public float cameraSpeed;

    
    [SerializeField] private bool inversedControl = false;
    
    private int controlDirection = -1;
   

    [SerializeField] private Vector3 offset;
    public GameObject PlayerRef;
    public Vector2 rotation;

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
        
        this.enabled = true;
        PlayerRef = Objects.Instance.Alpha;
        CameraMovement();
        
        
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

    private void CameraMovement()
    {
        transform.position = PlayerRef.transform.position + (PlayerRef.transform.right * offset.x) + PlayerRef.transform.up * offset.y + (-PlayerRef.transform.forward * offset.z);

        rotation.x += InputTester.inputInstance._playerInputs.Actions.RotateCameraX.ReadValue<float>() * cameraSpeed * Time.deltaTime * controlDirection;
        rotation.y -= InputTester.inputInstance._playerInputs.Actions.RotateCameraY.ReadValue<float>() * cameraSpeed * Time.deltaTime * controlDirection;
        rotation.x = Mathf.Clamp(rotation.x, -35, 60);

       // PlayerRef.transform.rotation = Quaternion.Euler(0, rotation.y, 0);
        transform.rotation = Quaternion.Euler(rotation.x, rotation.y, 0);
    }
}
