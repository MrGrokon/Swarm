using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackMover : MonoBehaviour
{

    [SerializeField] private float speed;
    
    private float health;

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
            rb.transform.position += InputTester.inputInstance.direction * speed * Time.fixedDeltaTime;
            //transform.parent.eulerAngles = Vector3.RotateTowards(transform.parent.position,  Rotation selon la direction du déplacement afin de garder la formation dans la direction du déplacement
                //InputTester.inputInstance.direction, speed * Time.deltaTime, 0.0f);
        }
    }

    public float GetHealth()
    {
        return health;
    }

    public void SetHealth(float ammount)
    {
        health = ammount;
    }
}
