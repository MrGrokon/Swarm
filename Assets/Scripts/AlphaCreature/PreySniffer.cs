using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreySniffer : MonoBehaviour
{
    [HideInInspector]
    public GameObject proof;
    private GameObject target;
    
    [Range(1f, 15f)]
    public float TimeToHunt = 5f;
    private float TimePassed;
    
    private LineRenderer trail;
    private bool OnHunt;
    private bool inputTriggered = false;

    #region Unity Functions
        private void Awake() {
            trail = GameObject.Find("TrackRenderer").GetComponent<LineRenderer>();
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
                TimePassed = TimePassed + Time.deltaTime;
                if(TimePassed < TimeToHunt){
                    trail.SetPosition(0, Objects.Instance.Alpha.transform.position);
                    trail.SetPosition(1, target.transform.position);
                    FadeOutTrail(Mathf.Lerp(0f, TimeToHunt, TimePassed));
                }
                else{
                    ResetTrackerValue();
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
    #endregion

    private void GetPrey()
    {
        target = proof.GetComponent<DetectPlayer>().prey;
        trail.SetPosition(0, Objects.Instance.Alpha.transform.position);
        trail.SetPosition(1, target.transform.position);
        OnHunt = true;
    }

    private void FadeOutTrail(float _LerpedValue){
        /*trail.colorGradient.alphaKeys.SetValue(new GradientAlphaKey(_LerpedValue * 255f, 0f), 0);
        trail.colorGradient.alphaKeys.SetValue(new GradientAlphaKey(_LerpedValue * 255f, 1f), 1);*/

        //TODO: fadeout of the trail, maybe by shader
          
    }

    public void ResetTrackerValue(){
        trail.gameObject.SetActive(false);
        TimePassed = 0f;
        target = null;
        OnHunt =false;
    }
}
