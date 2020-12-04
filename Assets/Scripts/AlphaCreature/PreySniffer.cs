using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreySniffer : MonoBehaviour
{
    public GameObject proof;
    private GameObject target;
    [SerializeField] private LineRenderer trail;
    [SerializeField] private bool OnHunt;
    private bool inputTriggered = false;

    private void GetPrey()
    {
        target = proof.GetComponent<DetectPlayer>().prey;
        trail.SetPosition(0, Objects.Instance.Alpha.transform.position);
        trail.SetPosition(1, target.transform.position);
        OnHunt = true;
    }

    private void LateUpdate()
    {
        if (InputTester.inputInstance._playerInputs.Actions.GetPrey.ReadValue<float>() != 0 && !inputTriggered)
        {
            trail.gameObject.SetActive(true);
            GetPrey();
            inputTriggered = true;
        }

        if (OnHunt && target)
        {
            trail.SetPosition(0, Objects.Instance.Alpha.transform.position);
            trail.SetPosition(1, target.transform.position);
            if (InputTester.inputInstance._playerInputs.Actions.GetPrey.ReadValue<float>() != 0 && !inputTriggered)
            {
                OnHunt = false;
                trail.gameObject.SetActive(false);
            }
        }
        else
        {
            OnHunt = false;
            trail.gameObject.SetActive(false);
        }

        if (InputTester.inputInstance._playerInputs.Actions.GetPrey.ReadValue<float>() == 0 && inputTriggered)
        {
            inputTriggered = false;
        }
    }
}
