using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbableTree : MonoBehaviour
{
    public Vector3 startPosition;
    [SerializeField] private Transform highPoint;
    public bool atTop = false;
    private bool inputIsTriggered;

    public List<Transform> preyInRange = new List<Transform>(); 

    private void OnTriggerStay(Collider other)
    {
        if (InputTester.inputInstance._playerInputs.Actions.Climb.triggered && inputIsTriggered == false)
        {
            if (atTop)
            {
                Objects.Instance.Alpha.transform.position = startPosition;
                atTop = false;
                print("Je descends");
                inputIsTriggered = true;
            }
            else
            {
                
                if (other.gameObject == Objects.Instance.Alpha)
                {
                    startPosition = other.transform.position;
                    other.transform.position = highPoint.position;
                }
                print("Je monte");
                atTop = true;
                inputIsTriggered = true;
            }
        }

        if (inputIsTriggered)
        {
            StartCoroutine(inputInterval());
        }

        if (InputTester.inputInstance._playerInputs.Actions.Attack.triggered && preyInRange.Count != 0)
        {
            Objects.Instance.Alpha.transform.position = preyInRange[0].position;
            Objects.Instance.Alpha.GetComponent<Attack>().DistantAttackCall(preyInRange[0].gameObject);
            preyInRange.Remove(preyInRange[0]);
            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Objects.Instance.Alpha)
        {
            atTop = false;
            inputIsTriggered = false;
        }
        else if (other.transform.CompareTag("Prey"))
        {
            preyInRange.Remove(other.transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Prey"))
        {
            preyInRange.Add(other.transform);
        }
    }


    IEnumerator inputInterval()
    {
        yield return new WaitForSeconds(0.2f);
        inputIsTriggered = false;
    }

}
