using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BetaCreature_Creator : MonoBehaviour
{
    [SerializeField] private float creatureCost;
    [SerializeField] private GameObject betaPrefab;

    private void Update()
    {
        if(InputTester.inputInstance._playerInputs.Actions.CreateBeta.triggered && GetComponent<RessourceManager>().Hunger <= creatureCost) //Inclure également le cout de la création dans le if
            CreateBeta();
    }

    private void CreateBeta()
    {
        var creature = Instantiate(betaPrefab, Random.insideUnitSphere * 5, Quaternion.identity);
        GetComponent<RessourceManager>().Hunger -= creatureCost;
        PackManager.packInstance.Add_PackMember(creature);
    }
}
