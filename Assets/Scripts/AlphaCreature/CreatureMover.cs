using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMover : MonoBehaviour
{
    private Rigidbody _rb;

    public float SprintSpeed;
    public float BaseSpeed;

    [Header("Sprint Parameters")]
    public float TimeToReachFullSpeed = 1f;
    public float TimeToLooseSpeed = 5f;
    public AnimationCurve AccelerationCurve, DecelerationCurve;
    private float TimeSinceLastInput = 0f;
    private bool IsSprinting;

    //Matérial Parameter
    [Header("Material Parameters")]
    private Material Basic_Mat;
    public Material WaitForInput_Mat, NoInput_Mat;
    

    #region Unity Functions
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
        #endregion
        
    }
    #endregion

    public void Move(Vector3 direction, float _sprintMultiplier = 1f)
    {
        Vector3 fwdCameraDirection = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
        Vector3 rgtCameraDirection = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z); 
        Debug.DrawRay(Camera.main.transform.position, fwdCameraDirection , Color.blue);

        #region movementRegion

        if (InputTester.inputInstance.direction.z != 0)
        {
            _rb.transform.position += fwdCameraDirection * InputTester.inputInstance.direction.z * BaseSpeed * _sprintMultiplier * Time.fixedDeltaTime;

        }

        if (InputTester.inputInstance.direction.x != 0)
        {
            _rb.transform.position += rgtCameraDirection * InputTester.inputInstance.direction.x * BaseSpeed * _sprintMultiplier * Time.fixedDeltaTime;
        }
        

        #endregion
        
    }

    private void SprintInput(){
        //Keyframe _k = new Keyframe(0, lerp)
        //réévalué la 1er keyframe par rapport à la dif entre actual speed (...) et max speed(BaseSpeed * SprintMultiplier)
        //AccelerationCurve.MoveKey(0, )
    }
}
