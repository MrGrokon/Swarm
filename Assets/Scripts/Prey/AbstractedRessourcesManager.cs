using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractedRessourcesManager : MonoBehaviour
{
    [SerializeField] private float RessourcesLosePerSeconds = 1f;
    private float MaxLevelRessources = 100f;
    public float FoodLevel, ThirstLevel;
    private PreyAiManager AI_Brain;

    #region Unity Functions
    private void Awake() {
        AI_Brain = this.GetComponent(typeof(PreyAiManager)) as PreyAiManager;
        FoodLevel = SetRandomRessourceLevel();
        ThirstLevel = SetRandomRessourceLevel();
    }

    private void Update() {
        FoodLevel -= RessourcesLosePerSeconds * Time.deltaTime;
        ThirstLevel -= RessourcesLosePerSeconds * Time.deltaTime;

        #region Hunger Manager
        if(FoodLevel <= 0f){
            if(AI_Brain.IsAlreadyLooking() == false){
                AI_Brain.CheckOutFor("Food");
                //TODO: wait to be in food range to give food back
                FoodLevel = MaxLevelRessources;
            }
        }
        #endregion

        #region Thirst Manager
        if(ThirstLevel <= 0f){
            if(AI_Brain.IsAlreadyLooking() == false){
                AI_Brain.CheckOutFor("Water");
                //TODO: wait to be in water range to give food back
                ThirstLevel = MaxLevelRessources;
            }
        }
        #endregion 
    }
    #endregion

    public void RestoreRessources(string _rsc){
        switch(_rsc){
            case "Food":
            FoodLevel = MaxLevelRessources;
            break;

            case "Water":
                ThirstLevel = MaxLevelRessources;
            break;

            default:
            Debug.Log("RestoreRessources() parrametter incoherant");
            break;
        }
    }

    #region Low Level Functions
    private float SetRandomRessourceLevel(){
        return Random.Range(0f, MaxLevelRessources);
    }
    #endregion
}
