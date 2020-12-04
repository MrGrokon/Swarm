using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CreatureIntelligence : MonoBehaviour
{
    public enum MyState
    {
        Follow,
        Attack
    };

    private Transform target;

    [SerializeField] private MyState state;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            MoveTo();
        }
    }

    public void SwitchState()
    {
        switch (state)
        {
            case MyState.Follow:
                
                break;
            case MyState.Attack:
                break;
        }
    }

    public void ChangeState(MyState newState)
    {
        state = newState;
    }

    private void MoveTo()
    {
        
    }
}
