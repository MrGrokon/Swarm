using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CreatureMover : MonoBehaviour
{
    private Rigidbody rb;

    public float speedMultiplier;
    public float maxSpeedMultiplier;
    [SerializeField] private float multiplierAddedAtEachInput;
    [SerializeField] private float multiplierLosseOverTime;
    public float speed;
    [SerializeField] private float acceleration;
    public float maxSpeed;
    private Vector3 actualDirection;

    [SerializeField] private int sprintState;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var gamepad = Gamepad.current;
        Move(InputTester.inputInstance.direction);
        if (InputTester.inputInstance.direction != Vector3.zero)
        {
            speed += acceleration * Time.deltaTime;
        }
        else
        {
            speed -= acceleration * Time.deltaTime;
        }
        speed = Mathf.Clamp(speed, 0, maxSpeed);
        if (gamepad.rightTrigger.wasPressedThisFrame && sprintState == 1)
        {
            SprintStateManager();
        }
            
        else if(gamepad.leftTrigger.wasPressedThisFrame && sprintState == 2)
            SprintStateManager();

        speedMultiplier -= multiplierLosseOverTime * Time.deltaTime;
        speedMultiplier = Mathf.Clamp(speedMultiplier, 1, maxSpeedMultiplier);

    }

    public void Move(Vector3 direction)  //Player Movement
    {
        if (InputTester.inputInstance.direction != Vector3.zero)
        {
            actualDirection = direction;
        }

        //Directions de la caméra
        Vector3 fwdCameraDirection = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
        Vector3 rgtCameraDirection = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z); 
        
        Debug.DrawRay(Camera.main.transform.position, fwdCameraDirection , Color.blue);

        #region movementRegion

        if (actualDirection.z != 0)
        {
            rb.transform.position += fwdCameraDirection * actualDirection.z * speed * speedMultiplier * Time.fixedDeltaTime;
        }

        if (actualDirection.x != 0)
        {
            rb.transform.position += rgtCameraDirection * actualDirection.x * speed * speedMultiplier * Time.fixedDeltaTime;
        }
        
        if (speedMultiplier < 1.2f)
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
        

        #endregion
        
    }

    private void SprintStateManager()
    {
        print("1");
        switch (sprintState)
        {
            case 1:
                speedMultiplier += multiplierAddedAtEachInput;
                sprintState = 2;
                GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case 2:
                speedMultiplier += multiplierAddedAtEachInput;
                sprintState = 1;
                GetComponent<Renderer>().material.color = Color.green;
                break;
        }

    }
}
