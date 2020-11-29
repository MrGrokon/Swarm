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

    private void Update() {
        Vector3 _joystickDir = new Vector3(Inputs.Actions.MoveRL.ReadValue<float>(), 0f, Inputs.Actions.MoveFB.ReadValue<float>()).normalized;
        if(_joystickDir != Vector3.zero){
            Debug.DrawRay(CreatureManager.Instance.GetCenterOfMass(), _joystickDir *3, Color.black);
            GameObject _masterCreature = CreatureManager.Instance.GetLeaderDynamically(_joystickDir);
            Debug.DrawRay(_masterCreature.transform.position, _joystickDir*3, Color.red);
            _masterCreature.GetComponent<CreatureAction_Interface>().ChangeCreatureAction(CreatureAction_Interface.CreatureAction.Motion);
        }
        else{
            //TODO: faire un truck pour faire revenir les creatures en Static
        }
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
