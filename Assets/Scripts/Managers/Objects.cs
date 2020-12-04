using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    public static Objects Instance;

    public GameObject Alpha;

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
}
