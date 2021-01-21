using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class Bushes_PostProcessing_Manager : MonoBehaviour
{
    
    public PostProcessProfile PP_profile;
    private Vignette _Vignette;
    public bool VignetteIsActive;

    [Range(0.01f, 1f)]
    public float MaxVignetteIntensity = 0.3f, TimeToDisplay =0.5f;

    private void Start() {
       _Vignette = PP_profile.GetSetting<Vignette>();
    }

    private void OnTriggerEnter(Collider trig) {
        if(trig.tag == "Bushes"){
            VignetteIsActive = true;
            DisplayVignette(VignetteIsActive);
        }
    }

    IEnumerator DisplayVignette(bool isAlreadyActive){
        if(isAlreadyActive == false){
            
        }
        yield return null;
    }
}
