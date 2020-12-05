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
        Vector3 CameraDirection = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
        Debug.DrawRay(transform.position, CameraDirection, Color.red);
        if(InputTester.inputInstance._playerInputs.Actions.MovementMode.triggered)
            rb.transform.position += CameraDirection * speed * speedMultiplier * Time.fixedDeltaTime;
        else
        {
            rb.transform.position += CameraDirection * speed * Time.fixedDeltaTime;
        }
    }
}
