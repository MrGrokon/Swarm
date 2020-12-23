using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Objects : MonoBehaviour
{
    public static Objects Instance;
    public enum ObjectType{ WaterSource, FoodSource};

    public GameObject Alpha;
    public List<GameObject> WaterSource = new List<GameObject>();
    public List<GameObject> FoodSource = new List<GameObject>();

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
                if(FoodSource.Contains(_object) == false){
                    FoodSource.Add(_object);
                }
            break;

            case ObjectType.WaterSource:
                if(WaterSource.Contains(_object) == false){
                    WaterSource.Add(_object);
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
            if(FoodSource.Count > 0){
                FoodSource.OrderBy(x => Vector3.Distance(CloserTo.transform.position, x.transform.position));
                return FoodSource[0].transform.position;
            }
            break;

            case ObjectType.WaterSource:
            if(WaterSource.Count > 0){
                WaterSource.OrderBy(x => Vector3.Distance(CloserTo.transform.position, x.transform.position));
                return WaterSource[0].transform.position;
            }
            break;
        }
        Debug.Log("GetCloserRessources() Failed");
        return Vector3.zero;
    }
    #endregion
}
