using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMover : MonoBehaviour
{
    private Rigidbody _rb;

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

    
    void FixedUpdate()
    {
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
        if (InputTester.inputInstance._playerInputs.Actions.RightSprintButton.ReadValue<float>() != 0 && sprintState == 1)
        {
            SprintStateManager();
        }
        else if (InputTester.inputInstance._playerInputs.Actions.LeftSprintButton.ReadValue<float>() != 0 && sprintState == 2)
        {
            SprintStateManager();
        }

        speedMultiplier -= multiplierLosseOverTime * Time.deltaTime;
        speedMultiplier = Mathf.Clamp(speedMultiplier, 1, maxSpeedMultiplier);

    }
    #endregion

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
