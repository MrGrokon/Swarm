﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    [Tooltip("Impulsion à chaque input de sprint")]
    [SerializeField] private float impulseForceByEachStep;

    [SerializeField] private int sprintState;
    [Tooltip("Montant de nourriture consommé à chaque input de sprint")]
    [SerializeField] private float amountOfFoodConsumedBySprint;

    [SerializeField] private ParticleSystem playerStepPS;
    [SerializeField] private ParticleSystem playerSpeedPS;

    #region Unity Functions
    void Start()
    {
        speed = 0;
        _rb = GetComponent<Rigidbody>();
    }

    
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
    #endregion

    public void Move(Vector3 direction)  //Player Movement
    {
        if (InputTester.inputInstance.direction != Vector3.zero)
        {
            actualDirection = direction;
            transform.rotation = Quaternion.LookRotation(new Vector3(Camera.main.transform.forward.x,0, Camera.main.transform.forward.z));
        }

        

        #region movementRegion

        if (actualDirection.z != 0)
        {
            _rb.transform.position += new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z) * actualDirection.z * speed * speedMultiplier * Time.fixedDeltaTime;
        }

        if (actualDirection.x != 0)
        {
            _rb.transform.position += new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z) * actualDirection.x * speed * speedMultiplier * Time.fixedDeltaTime;
        }
        
        if (speedMultiplier < 1.2f)
        {
            GetComponent<Renderer>().material.color = Color.white;
            
        }

        if (_rb.velocity.magnitude > 0.5f && speedMultiplier > 1.2f)
        {
            playerSpeedPS.Play();
        }
        else
        {
            playerSpeedPS.Stop();
        }
        

        #endregion
        
    }

    private void SprintStateManager()
    {
        playerStepPS.Play();
        print(1);
        switch (sprintState)
        {
            case 1:
                speedMultiplier += multiplierAddedAtEachInput;
                sprintState = 2;
                GetComponent<RessourceManager>().LooseRessource(RessourceManager.Resource.Hunger, amountOfFoodConsumedBySprint);
                _rb.AddForce(_rb.transform.forward * impulseForceByEachStep * 100, ForceMode.Impulse);
                GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case 2:
                speedMultiplier += multiplierAddedAtEachInput;
                sprintState = 1;
                GetComponent<RessourceManager>().LooseRessource(RessourceManager.Resource.Hunger, amountOfFoodConsumedBySprint);
                _rb.AddForce(_rb.transform.forward * impulseForceByEachStep * 100, ForceMode.Impulse);
                GetComponent<Renderer>().material.color = Color.green;
                break;
        } 
        //playerPS.Stop();
    }
}
