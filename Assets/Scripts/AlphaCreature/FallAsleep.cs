using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallAsleep : MonoBehaviour
{
    private RessourceManager _ressource;
    private CreatureMover _mover;
    [HideInInspector]
    public bool IsAsleep = false;
    [Range(3f, 20f)]
    public float TimeToRecoverHunger = 10f;
    private float TimePassedSinceAsleep = 0f;

    #region Unity Functions
    private void Awake() {
        _ressource = this.GetComponent<RessourceManager>();
        if(_ressource == null){
            Debug.Log("Critical Error: RessourceManager not found");
        }
        _mover = this.GetComponent<CreatureMover>();
        if(_mover == null){
            Debug.Log("Critical Error: CreatureMover Not found");
        }
    }

    private void Update() {
        #region Test if im starving
        if(_ressource.GetRessource(RessourceManager.Resource.Hunger) <= 0f){
            Debug.Log("I starve and fall asleep");
            Alpha_FallAsleep();
        }
        #endregion

        #region Asleep Loop
        if(IsAsleep == true){
            TimePassedSinceAsleep += Time.deltaTime;
            float _amountOfFood = (_ressource.GetMax(RessourceManager.Resource.Hunger) * Time.deltaTime) / TimeToRecoverHunger;
            // (MaxHunger * Time.deltaTime) -> get back full life about 1sec
            // So, dividing it by X seconds should get back full life in about Xsec
            _ressource.GainRessource(RessourceManager.Resource.Hunger, _amountOfFood);
            if(TimePassedSinceAsleep >= TimeToRecoverHunger || _ressource.GetRessource(RessourceManager.Resource.Hunger) ==_ressource.GetMax(RessourceManager.Resource.Hunger)){
                Debug.Log("Im back with a full belly");
                Alpha_WakeUp();
            }
        }
        #endregion
    }
    #endregion

    public void Alpha_FallAsleep(){ //Effet de sommeil quand le joueur n'a plus de nourriture
        IsAsleep = true;
        //TODO: Disable the character controler
        _mover.enabled = false;
    }
    public void Alpha_WakeUp(){  //Réveil du joueur
        IsAsleep = false;
        TimePassedSinceAsleep = 0f;
        //TODO: Enable the character controler
        _mover.enabled = true;
    }
}
