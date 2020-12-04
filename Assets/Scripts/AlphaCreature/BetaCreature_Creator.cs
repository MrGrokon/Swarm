using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BetaCreature_Creator : MonoBehaviour
{
    [SerializeField] private float creatureCost = 10f;
    [SerializeField] private GameObject betaPrefab;

    private void Update()
    {
        if(InputTester.inputInstance._playerInputs.Actions.CreateBeta.triggered)
            CreateBeta();
    }

    private void CreateBeta()
    {
        RessourceManager _resources = GetComponent<RessourceManager>();
        if(_resources.Hunger - creatureCost > 0f){
            Debug.Log("i Created a Beta");
            _resources.LooseRessource(RessourceManager.Resource.Hunger, creatureCost);

            //TODO: changer le This.transform.position, par une position d'apparition définie pour le beta
            GameObject _betaCreature = Instantiate(betaPrefab, this.transform.position, Quaternion.identity);
            PackManager.packInstance.Add_PackMember(_betaCreature);
        }
        else{
            Debug.Log("Not enougth Hunger to create a Beta");
        }
    }
}
