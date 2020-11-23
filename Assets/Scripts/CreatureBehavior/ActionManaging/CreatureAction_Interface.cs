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
        ChangeCreatureAction(CreatureAction.Motion);
    }   
    

    private void Update()
    {
        if (InputTester.input_Instance.Inputs.Actions.MoveFB.ReadValue<float>() != 0)
        {
            var dirValue = InputTester.input_Instance.Inputs.Actions.MoveFB.ReadValue<float>();
            Vector3 direction = new Vector3(Camera.main.transform.forward.x,0,Camera.main.transform.forward.z); //Prendre en compte le forward de la caméra pour la direction
            this.GetComponent<CreatureMover>().Move(direction);
        }

        if (InputTester.input_Instance.Inputs.Actions.MoveRL.ReadValue<float>() != 0)
        {
            var dirValue = InputTester.input_Instance.Inputs.Actions.MoveRL.ReadValue<float>();
            Vector3 direction = new Vector3(Camera.main.transform.forward.x,0,Camera.main.transform.forward.z); //Prendre en compte le forward de la caméra pour la direction
            this.GetComponent<CreatureMover>().Move(direction);
        }
        Debug.DrawRay(Camera.main.transform.position, new Vector3(Camera.main.transform.forward.x,0,Camera.main.transform.forward.z) * 5f, Color.red);
    }

    #region Creature Action Management
    public void ChangeCreatureAction(CreatureAction _action)
    {
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

    public static bool Is_A_PriorTo_B(CreatureAction A, CreatureAction B)
    {
        int A_priority, B_priority;
        CreatureActionByPriority.TryGetValue(A, out A_priority);
        CreatureActionByPriority.TryGetValue(B, out B_priority);
        /*if(A_priority == null || B_priority == null)
        {
            Debug.Log("A or B is Null");
            return null;
        }*/
        //else{
        if(A_priority > B_priority)
        {
            return true;
        }
        return false;
        //}
    }
    #endregion
}
