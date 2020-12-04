using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTester : MonoBehaviour
{

    public static InputTester inputInstance;
    private PlayerInputs _playerInputs;

    public Vector3 direction;
    // Start is called before the first frame update
    private void Awake()
    {
        _playerInputs = new PlayerInputs();
        
        if (inputInstance == null)
        {
            inputInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(_playerInputs.Actions.MoveRL.ReadValue<float>(), 0, _playerInputs.Actions.MoveFB.ReadValue<float>());
    }

    private void OnEnable()
    {
        _playerInputs.Enable();
    }

    private void OnDisable()
    {
        _playerInputs.Disable();
    }
}
