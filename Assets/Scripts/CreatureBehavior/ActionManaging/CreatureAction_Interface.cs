using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureAction_Interface : MonoBehaviour
{
    [Header("Mecanic Related")]
    public CreatureAction MyAction;
    public enum CreatureAction { Static, Motion, Climb, Cross, Eat}

    #region Definition Dictionaire
    public static Dictionary<CreatureAction, int> CreatureActionByPriority = new Dictionary<CreatureAction, int>
    {
        {CreatureAction.Static, 0},
        {CreatureAction.Motion, 1},
        {CreatureAction.Cross, 2},
        {CreatureAction.Climb, 3},
        {CreatureAction.Eat, 4}
    };
    #endregion

    #region Private vars
    MeshRenderer _renderer;
    private CreatureMover _Mover;

    Vector3 _joystickDir;
    #endregion

    [Header("Matérials Assignation")]
    public Material StandardMaterial;
    public Material MotionMaterial;
    public Material EatMaterial;
    public Material CrossMaterial;
    public Material ClimbMaterial;

    private void Start()
    {
        CreatureManager.Instance.AddCreature(this.gameObject);
        _renderer = this.GetComponent<MeshRenderer>();
        ChangeCreatureAction(CreatureAction.Static);
        _Mover = this.GetComponent<CreatureMover>();
    }   
    

    private void Update()
    {
        Vector3  _joystickDir = new Vector3(InputTester.input_Instance.Inputs.Actions.MoveRL.ReadValue<float>(), 0f, InputTester.input_Instance.Inputs.Actions.MoveFB.ReadValue<float>()).normalized;
        if(_joystickDir != Vector3.zero){
            switch (MyAction){
           
                case CreatureAction.Motion:
                    Vector3 direction = new Vector3(Camera.main.transform.forward.x,0,Camera.main.transform.forward.z); //Prendre en compte le forward de la caméra pour la direction
                    //TODO: project on plane de du movement joystick par rapport au ground en prenant en compte les Left/Right de la camera
                    _Mover.Move(_joystickDir);
                    break;

                    default:
                    Debug.Log("CreatureAction_Interface -> someting fucked up !");
                    break;
            }
        }
        else
        {
            //l'info ne s'applique pas, car le systeme de priorité l'override
            //CA TJR PAS MARCHE !
            ChangeCreatureAction(CreatureAction.Static);
        }
    }

    #region Creature Action Management
    public void ChangeCreatureAction(CreatureAction _action)
    {
        if(MyAction != _action){
            switch (_action)
            {
                case CreatureAction.Static:
                    _renderer.material = StandardMaterial;
                    break;

                case CreatureAction.Motion:
                    _renderer.material = MotionMaterial;
                    break;

                case CreatureAction.Climb:
                    _renderer.material = ClimbMaterial;
                    break;

                case CreatureAction.Cross:
                    _renderer.material = CrossMaterial;
                    break;


                case CreatureAction.Eat:
                    _renderer.material = EatMaterial;
                    break;
            }
            MyAction = _action;
        } 
    }

    public static bool Is_A_PriorTo_B(CreatureAction A, CreatureAction B)
    {
        int A_priority, B_priority;
        CreatureActionByPriority.TryGetValue(A, out A_priority);
        CreatureActionByPriority.TryGetValue(B, out B_priority);

        if(A_priority > B_priority)
        {
            //Debug.Log("a>b");
            return true;
        }
        if(A_priority == B_priority){
            //Debug.Log("a == b");
            return false;
        }
        //Debug.Log("A < B");
        return false;
    }
    #endregion
}
