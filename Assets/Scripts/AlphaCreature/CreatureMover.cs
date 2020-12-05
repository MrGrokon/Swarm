using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMover : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float speedMultiplier;

    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (InputTester.inputInstance.direction != Vector3.zero)
        {
            Move(InputTester.inputInstance.direction);
        }
        
    }

    public void Move(Vector3 direction)
    {
        Vector3 fwdCameraDirection = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
        Vector3 rgtCameraDirection = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z); 
        Debug.DrawRay(Camera.main.transform.position, fwdCameraDirection , Color.blue);

        #region movementRegion

        if (InputTester.inputInstance.direction.z != 0)
        {
            if(InputTester.inputInstance._playerInputs.Actions.MovementMode.triggered)
                rb.transform.position += fwdCameraDirection * InputTester.inputInstance.direction.z * speed * speedMultiplier * Time.fixedDeltaTime;
            else
            {
                rb.transform.position += fwdCameraDirection * InputTester.inputInstance.direction.z * speed * Time.fixedDeltaTime;
            } 
        }

        if (InputTester.inputInstance.direction.x != 0)
        {
            if(InputTester.inputInstance._playerInputs.Actions.MovementMode.triggered)
                rb.transform.position += rgtCameraDirection * InputTester.inputInstance.direction.x * speed * speedMultiplier * Time.fixedDeltaTime;
            else
            {
                rb.transform.position += rgtCameraDirection * InputTester.inputInstance.direction.x * speed * Time.fixedDeltaTime;
            } 
        }
        

        #endregion
        
    }
}
