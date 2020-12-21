using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMover : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField] private float speedMultiplier;
    [SerializeField] private float maxSpeedMultiplier;
    [SerializeField] private float multiplierAddedAtEachInput;
    [SerializeField] private float multiplierLosseOverTime;
    [SerializeField] private float speed;

    [SerializeField] private int sprintState;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Basic_Mat = this.GetComponent<MeshRenderer>().material;
    }

    
    void FixedUpdate()
    {
        #region Sprint
        if(InputTester.inputInstance._playerInputs.Actions.RT.ReadValue<float>() > 0f || InputTester.inputInstance._playerInputs.Actions.LT.ReadValue<float>() > 0f){
            
        }
        if(IsSprinting == true){
            TimeSinceLastInput += Time.fixedDeltaTime;
        }
        #endregion

        #region Motion
        if (InputTester.inputInstance.direction != Vector3.zero)
        {
            Move(InputTester.inputInstance.direction);
        }

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
        
        //Directions de la caméra
        Vector3 fwdCameraDirection = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
        Vector3 rgtCameraDirection = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z); 
        
        Debug.DrawRay(Camera.main.transform.position, fwdCameraDirection , Color.blue);

        #region movementRegion

        if (InputTester.inputInstance.direction.z != 0)
        {
            rb.transform.position += fwdCameraDirection * InputTester.inputInstance.direction.z * speed * speedMultiplier * Time.fixedDeltaTime;
        }

        if (InputTester.inputInstance.direction.x != 0)
        {
            rb.transform.position += rgtCameraDirection * InputTester.inputInstance.direction.x * speed * speedMultiplier * Time.fixedDeltaTime;
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
