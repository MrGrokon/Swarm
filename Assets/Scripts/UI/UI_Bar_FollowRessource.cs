﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Bar_FollowRessource : MonoBehaviour
{
    public RessourceManager.Resource Rsc_Followed;
    private Slider _slider;
    
    #region Unity Functions
        private void Start() {
            _slider = this.GetComponent<Slider>();
            if(_slider == null){
                Debug.Log("Slider Not Found: must be place on a UI Object");
            }
            else{
                _slider.maxValue = Objects.Instance.Alpha.GetComponent<RessourceManager>().GetMax(Rsc_Followed);
            }
            
        }

        private void Update() {
            _slider.value = Objects.Instance.Alpha.GetComponent<RessourceManager>().GetRessource(Rsc_Followed);
        }
    #endregion
}
