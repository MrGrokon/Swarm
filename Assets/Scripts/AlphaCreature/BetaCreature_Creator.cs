using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BetaCreature_Creator : MonoBehaviour
{
    //TODO: Unfold these parameters when bool is true
    [Header("Init Parameters")]
    [SerializeField]private bool InstanciateBetaOnStart = true;
    [Range(0, 5)]
    [SerializeField]private int NumberOfBetaToSpawn = 3;

    //[Space(20f)]

    [Header("Generic Parameters")]
    [Range(1f, 50f)]
    [SerializeField] private float creatureCost = 10f;
    [SerializeField] private GameObject betaPrefab;
    [Range(0, 50)]
    [SerializeField] private int maxPackMember;

    #region Unity Functions
    private void Start() {
        if(InstanciateBetaOnStart == true){
            for (int i = 0; i < NumberOfBetaToSpawn; i++)
            {
                InstanciateBeta();
            }
        }
    }

    private void Update()
    {
        if(InputTester.inputInstance._playerInputs.Actions.CreateBeta.triggered)
            CreateBeta();
    }
    #endregion

    private void CreateBeta()
    {
        RessourceManager _resources = GetComponent<RessourceManager>();
        if(_resources.Hunger - creatureCost > 0f && PackManager.packInstance.GetPackLenght() < maxPackMember){
            Debug.Log("I Created a Beta");
            _resources.LooseRessource(RessourceManager.Resource.Hunger, creatureCost);

            //TODO: changer le This.transform.position, par une position d'apparition définie pour le beta
            InstanciateBeta();
        }
        else{
            Debug.Log("Not enougth Hunger to create a Beta or too much pack member");
        }
    }

    #region Low Level Functions

    private void InstanciateBeta(){
        GameObject _betaCreature = Instantiate(betaPrefab, RandomPositionAroundAlpha(2f), Quaternion.identity);
        PackManager.packInstance.Add_PackMember(_betaCreature);
    }

    private Vector3 RandomPositionAroundAlpha(float OptionnalDistanceRange = 5f){
            Vector3 RandomPos = Random.insideUnitCircle;
            RandomPos.z = RandomPos.y;
            RandomPos.y = 0;
            RandomPos *= OptionnalDistanceRange;
            RandomPos += Objects.Instance.Alpha.transform.position;

            return RandomPos;
        }
    #endregion
}
