using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PreySniffer : MonoBehaviour
{
    //[HideInInspector]
    public List<GameObject> ProofsList = new List<GameObject>();
    
    /*[Range(1f, 15f)]
    public float TimeToHunt = 5f;
    private float TimePassed;*/
    
    private bool inputTriggered = false;

    #region Unity Functions

        private void Update() {
            if(InputTester.inputInstance._playerInputs.Actions.GetPrey.ReadValue<float>() != 0f && inputTriggered == false){
                Debug.Log("J'appuis sur btn getPrey");
                inputTriggered = true;
                if(ProofsList.Count > 0){
                    //this will sort the arrey so ProofList[0] will always be the closest to the alpha
                    ProofsList.OrderBy(x => Vector3.Distance(this.transform.position, x.transform.position));
                    ProofsList[0].GetComponent<TrackRenderer>().UseTrack();
                    //ProofsList[0].GetComponent<MeshRenderer>().material.SetColor("ACTIC", Color.white);
                }
            }
            #region InputReseter
            else{
                inputTriggered = false;
            }
            #endregion
        }

        #region Gestion de la ProofsList
        private void OnTriggerEnter(Collider _col) { //Ajout de la traçe dans la liste du joueur comme étant analysable
            if(_col.tag == "Track" && ProofsList.Contains(_col.gameObject) == false){
                ProofsList.Add(_col.gameObject);
                //_col.GetComponent<MeshRenderer>().material.SetColor("ACTIV", Color.white);
            }
        }

        private void OnTriggerExit(Collider _col) { //Suppression de la traçe dans la liste du joueur comme étant analysable
            if(_col.tag == "Track" && ProofsList.Contains(_col.gameObject)){
                ProofsList.Remove(_col.gameObject);
                //_col.GetComponent<MeshRenderer>().material.SetColor("ACTIV", Color.black);
            }
        }
        #endregion
    #endregion
}
