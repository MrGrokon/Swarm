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
    [SerializeField] private List<Transform> formationPoints;
    [SerializeField] private List<Vector3> formationPointsLocation;
    private bool crossTriggered = false;

    private void Update()
    {
        if(InputTester.inputInstance.formationAxis != Vector2.zero && crossTriggered == false)
            SetFormation("test", myFormation, InputTester.inputInstance.formationAxis);
        else if(InputTester.inputInstance.formationAxis == Vector2.zero)
        {
            crossTriggered = false;
        }
    }

    public void SetFormation(string str, formation _formation, Vector2 formationAxis)
    {
        crossTriggered = true;
        print("Setup de la formation...");
        switch (_formation)
        {
            case formation.Triangle:
                var player = ObjectsInstance._instance.Player;
                bool leftSide = true;
                for (int i = 0; i < PackManager.packInstance.GetPackLenght(); i++)
                {
                    if (i == 0)
                    {
                        formationPointsLocation.Add(new Vector3(player.transform.position.x - 1, 0,player.transform.position.z - 1));
                    }
                    else if (i == PackManager.packInstance.GetPackLenght() / 2)
                    {
                        formationPointsLocation.Add(new Vector3(player.transform.position.x - 1, 0,player.transform.position.z + 1));
                        leftSide = false;
                    }
                    else
                    {
                        if(leftSide)
                            formationPointsLocation.Add(new Vector3(formationPointsLocation[i-1].x - 1, 0,formationPointsLocation[i-1].z - 1));
                        else
                        {
                            formationPointsLocation.Add(new Vector3(formationPointsLocation[i-1].x - 1, 0,formationPointsLocation[i-1].z + 1));
                        }
                    }
                }
                break;
        }

        foreach (var position in formationPointsLocation)
        {
            var empty = Instantiate(new GameObject(), position, Quaternion.identity);
            empty.transform.parent = ObjectsInstance._instance.Player.transform;
        }
    }
}
