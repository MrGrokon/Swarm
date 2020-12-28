using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Objects : MonoBehaviour
{
    public static Objects Instance;
    public enum ObjectType{ WaterSource, FoodSource};

    public GameObject Alpha;
    public List<GameObject> WaterSources = new List<GameObject>();
    public List<GameObject> FoodSources = new List<GameObject>();

    private void Awake() {
        #region Singleton Instance

            if(Instance == null){
                Instance = this;
            }
            else{
                Destroy(this);
            }
        #endregion
    
        if(Instance != null){
            //Caution, we must find a better way to do such search
            Alpha = GameObject.Find("Alpha Creature");
        }
        else{
            Debug.Log("Critical Error -> Objects.Instance not working properly");
        }
    }

    #region Object Managing Functions
    public void AddAnObject(ObjectType _type, GameObject _object){
        switch (_type)
        {
            case ObjectType.FoodSource:
                if(FoodSources.Contains(_object) == false){
                    FoodSources.Add(_object);
                }
            break;

            case ObjectType.WaterSource:
                if(WaterSources.Contains(_object) == false){
                    WaterSources.Add(_object);
                }
            break;
            
            default:
            Debug.Log("AddAnObject() -> something fucked up");
            break;
        }
    }

    public Vector3 GetCloserRessources(ObjectType _type, GameObject CloserTo){
        switch(_type){
            case ObjectType.FoodSource:
            if(FoodSources.Count > 0){
                GameObject[] _tempsFoodSources = FoodSources.OrderBy(x => Vector3.Distance(x.transform.position, CloserTo.transform.position)).ToArray<GameObject>();
                return _tempsFoodSources[0].transform.position;
            }
            break;

            case ObjectType.WaterSource:
            if(WaterSources.Count > 0){

                GameObject[] _tempsWaterSources = WaterSources.OrderBy(x => Vector3.Distance(x.transform.position, CloserTo.transform.position)).ToArray<GameObject>();
                return _tempsWaterSources[0].transform.position;
            }
            break;
        }
        Debug.Log("GetCloserRessources() Failed");
        return Vector3.zero;
    }
    #endregion
}
