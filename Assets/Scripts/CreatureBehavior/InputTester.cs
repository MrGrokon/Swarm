using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTester : MonoBehaviour
{
    static public InputTester input_Instance;
    public PlayerInputs Inputs;

    private void Awake()
    {
        Inputs = new PlayerInputs();
        #region Singleton input_Instance
        if(input_Instance == null)
        {
            input_Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        #endregion
    }
    
    private void OnEnable()
    {
        Inputs.Enable();
    }

    private void OnDisable()
    {
        Inputs.Disable();
    }
}
