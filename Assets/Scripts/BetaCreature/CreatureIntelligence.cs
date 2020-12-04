using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;    WTF is that ?
using UnityEngine;

public class CreatureIntelligence : MonoBehaviour
{
    public enum CreatureState
    {
        Follow,
        Attack
    };

    [HideInInspector]
    public Transform Target;

    public CreatureState MyState;

    private void Update() {
        switch (MyState)
        {
            case CreatureState.Follow:
            break;

            case CreatureState.Attack:
            break;

            default:
            Debug.Log("Error: Creature State Incorect");
            break;
        }
    }
}
