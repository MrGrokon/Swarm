using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{

    public bool isTargeting = false;

    public Transform target;

    [SerializeField] private float maxDistanceToTarget;

    [SerializeField] private LayerMask targetMask;

    [SerializeField] private Collider[] targets;
    int index = 0;
    // Update is called once per frame
    void Update()
    {
        if (InputTester.inputInstance._playerInputs.Actions.Targeting.triggered)
        {
            isTargeting = !isTargeting;
            TargetingFunction();
        }

        if (target)
        {
            if (Vector3.Distance(transform.position, target.position) > maxDistanceToTarget)
            {
                isTargeting = false;
                TargetingFunction();
            }

            if (InputTester.inputInstance._playerInputs.Actions.SwitchTarget.triggered)
            {
                float axisValue = InputTester.inputInstance._playerInputs.Actions.SwitchTarget.ReadValue<float>();
                SwitchTarget(axisValue);
            }
        }
    }


    private void TargetingFunction()
    {
        if (FindNearestTarget())
        {
            if (isTargeting)
            {
                target = FindNearestTarget();
                GetComponentInChildren<ThridPersonCamera>().targetToLook = FindNearestTarget();
                GetComponentInChildren<CameraRotate>().enabled = false;
                
            }
            else
            {
                GetComponentInChildren<ThridPersonCamera>().targetToLook = null;
                GetComponentInChildren<CameraRotate>().enabled = true;
                target = null;
            }
        }
        else
        {
            isTargeting = false;
        }
        
        
    }


    private Transform FindNearestTarget()
    {
        targets = Physics.OverlapSphere(transform.position, maxDistanceToTarget, targetMask);
        if (targets.Length > 0)
        {
            GameObject nearestPrey = targets[0].gameObject;

            foreach (var target in targets)
            {
                if (Vector3.Distance(transform.position, target.transform.position) <
                    Vector3.Distance(transform.position, nearestPrey.transform.position))
                {
                    if(target.GetComponent<Renderer>().isVisible)
                        nearestPrey = target.gameObject;
                }
            } 
            return nearestPrey.transform;
        }
        else
        {
            return null;
        }
        
        
    }

    private void SwitchTarget(float value)
    {
        print("switch");
        
        targets = Physics.OverlapSphere(transform.position, maxDistanceToTarget, targetMask);
        if (targets.Length > 0)
        {
            index += (int)value;
            
            if (index > targets.Length - 1)
            {
                index = 0;
            }
            else if (index < 0)
            {
                index = targets.Length - 1;
            }
            print("index = " +index);
            if (targets[index].GetComponent<Renderer>().isVisible)
            {
                target = targets[index].transform;
                GetComponentInChildren<ThridPersonCamera>().targetToLook = target;
            }
            
        }
    }
}
