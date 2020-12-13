using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{

    /*
    BEWARE: this script shouldn't be used anymore
     */
    public GameObject prey;

    #region Unity Functions

    private void Start() {
        //ajoute a la liste de trace, cette trace si elle n'est pas déja dedant
        //evite les erreur pour les traces qui ne sont pas placer par le TracksCreatorOverTime
        TracksCreatorOverTime _trackManager = prey.GetComponent<TracksCreatorOverTime>();
        if(_trackManager.PreyTracks.Contains(this.gameObject) == false){
            _trackManager.PreyTracks.Add(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            //other.transform.GetComponent<PreySniffer>().proof = this.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            //other.transform.GetComponent<PreySniffer>().proof = null;
        }
    }
    
    #endregion
}
