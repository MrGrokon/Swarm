using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    [SerializeField] private List<GameObject> PreyInTrigger;

    private RessourceManager _ressource;

    private void Start() {
        _ressource = this.GetComponent<RessourceManager>();
    }

    #region Unity Function
    void Update()
    {
        if (InputTester.inputInstance._playerInputs.Actions.Attack.triggered)
        {
            foreach (var obj in PreyInTrigger)
            {
                
                _ressource.GainRessource(RessourceManager.Resource.Hunger, 20f);
                PreyAiManager actualManager = obj.GetComponent(typeof(PreyAiManager)) as PreyAiManager;
                PackManager.packInstance.gameObject.GetComponent<GeneratePrey>().listOfPrey.Remove(obj);
                PreyInTrigger.Remove(obj);
                actualManager.Die();
                //GetComponent<PreySniffer>().ResetTrackerValue();
            }
        }
    }

    
    //Fonction pour déclenché l'attaque via un autre script
    public void DistantAttackCall(GameObject prey)
    {
        _ressource.GainRessource(RessourceManager.Resource.Hunger, 20f);
        PackManager.packInstance.gameObject.GetComponent<GeneratePrey>().listOfPrey.Remove(prey);
        prey.GetComponent<PreyAiManager>().Die();
        //GetComponent<PreySniffer>().ResetTrackerValue();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Prey"))
        {
            PreyInTrigger.Add(other.transform.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Prey"))
        {
            PreyInTrigger.Remove(other.transform.gameObject);
        }
    }
    #endregion
}
