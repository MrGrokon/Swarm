using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMover : MonoBehaviour
{
    private Rigidbody rb;
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
        rb.transform.position += direction * Time.fixedDeltaTime;
    }
}
