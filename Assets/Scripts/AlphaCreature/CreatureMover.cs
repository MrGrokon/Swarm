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
        if(InputTester.inputInstance._playerInputs.Actions.MovementMode.triggered)
            rb.transform.position += direction * speed * speedMultiplier * Time.fixedDeltaTime;
        else
        {
            rb.transform.position += direction * speed * Time.fixedDeltaTime;
        }
    }
}
