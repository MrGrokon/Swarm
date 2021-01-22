using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BushesDynamicsEffects : MonoBehaviour
{
    public PostProcessProfile PP_profile;
    public bool IsAlreadyInBush = false;

    private Vignette _Vignette;
    [Range(0.1f, 1f)]
    public float MaxVignetteIntensity = 0.3f, TimeToFullIntensity = 0.5f;

    private void Start() {
        _Vignette = PP_profile.GetSetting<Vignette>();
    }
    

    private void OnTriggerEnter(Collider trig) {
         if(trig.tag == "Bushes"){
             StartCoroutine(ActiveVignette(IsAlreadyInBush));
             IsAlreadyInBush = true;
         }
    }

    private IEnumerator ActiveVignette(bool IsInBush){
        float _timePassed = 0f;
        while(_timePassed <= 1f){
            _timePassed += Time.deltaTime / TimeToFullIntensity;
            Debug.Log("time: " + _timePassed);
            _Vignette.intensity.value = _timePassed * MaxVignetteIntensity;
        }
        yield return null;
    }

    IEnumerator DisableVignette(){
        yield return null;
    }
}
