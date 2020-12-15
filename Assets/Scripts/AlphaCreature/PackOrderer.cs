using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackOrderer : MonoBehaviour
{
    public enum formation
    {
        Triangle,
        Round,
        Null
    };

    [SerializeField] private formation myFormation;
    public List<Transform> formationPoints = new List<Transform>();
    private List<Vector3> formationPointsLocation = new List<Vector3>();
    private bool crossTriggered = false;
    public bool isInFormation = false;

    [SerializeField] private GameObject formationPointPrefab;

    private void Update()
    {
        if(isInFormation){
            PackManager.packInstance.SetFormationPoint();
        }

        if(InputTester.inputInstance.formationAxis != Vector2.zero && crossTriggered == false){
            isInFormation = ! isInFormation;

            if(isInFormation){
                SetFormation( myFormation);
            }
            else{
                PackManager.packInstance.FreeAllBetas();
            }
            
            
        }
        else if(InputTester.inputInstance.formationAxis == Vector2.zero)
        {
            crossTriggered = false;
        }
    }

    //Mise en place d'une formlation selon la formation choisi
    public void SetFormation(formation _formation) 
    {
        foreach (var empty in formationPoints)
        {
            Destroy(empty.gameObject);
        }
        formationPoints.Clear();
        formationPointsLocation.Clear();
        crossTriggered = true;
        print("Setup de la formation...");
        switch (_formation)
        {
            case formation.Triangle:
                var player = Objects.Instance.Alpha;
                bool leftSide = true;
                for (int i = 0; i < PackManager.packInstance.GetPackLenght(); i++)
                {
                    if (i == 0)
                    {
                        formationPointsLocation.Add(new Vector3(player.transform.position.x - 1, 0,player.transform.position.z - 1));
                    }
                    else if (i == PackManager.packInstance.GetPackLenght() / 2)
                    {
                        formationPointsLocation.Add(new Vector3(player.transform.position.x + 1, 0,player.transform.position.z - 1));
                        leftSide = false;
                    }
                    else
                    {
                        if(leftSide)
                            formationPointsLocation.Add(new Vector3(formationPointsLocation[i-1].x - 1, 0,formationPointsLocation[i-1].z - 1));
                        else
                        {
                            formationPointsLocation.Add(new Vector3(formationPointsLocation[i-1].x + 1, 0,formationPointsLocation[i-1].z - 1));
                        }
                    }
                } 
                break;
        }

        //Création des positions de formations
        foreach (var position in formationPointsLocation)  
        {
            var empty = Instantiate(formationPointPrefab, position, Quaternion.identity);
            empty.transform.parent = Objects.Instance.Alpha.transform;
            formationPoints.Add(empty.transform);
            print("Passage");
        }
    }
}
