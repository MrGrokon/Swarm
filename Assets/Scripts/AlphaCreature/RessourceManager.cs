using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceManager : MonoBehaviour
{
    private float _health;
    private float _hunger;
    public float MaxHealth =100f, MaxHunger=100f;

    public float AmountOfHungerLoosePerSeconds = 2f;

    #region Geter & Seter
    public float Hunger
    {
        get => _hunger;
        set => _hunger = value;
    }

    public float Health
    {
        get => _health;
        set => _health = value;
    }
    #endregion

    public enum Resource{Health, Hunger};

    #region Date Returning Functions
        public float GetRessource(Resource TryedType){
            switch (TryedType)
            {
                case Resource.Hunger:
                return _hunger;

                case Resource.Health:
                return _health;
                
                default:
                Debug.Log("GetRessource() -> Something fuckedUp");
                break;
            }
            Debug.Log("Swith Inoperant -> Critical Error on GetRessources()");
            return -1f;
        }

        public float GetMax(Resource TryedType){
            switch (TryedType)
            {
                case Resource.Hunger:
                return MaxHunger;

                case Resource.Health:
                return MaxHealth;
                
                default:
                Debug.Log("GetMax() -> Something fuckedUp");
                break;
            }
            Debug.Log("Swith Inoperant -> Critical Error on GetMax()");
            return -1f;
        }
    #endregion

    #region Resources Managing Functions
    public void GainRessource(Resource TryedResource, float amount)
    {
        switch (TryedResource)
        {
            case Resource.Health:
                if(Health + amount >= MaxHealth){
                    Health = MaxHealth;
                }
                else{
                    Health += amount;
                }
            break;

            case Resource.Hunger:
            if(Hunger + amount >= MaxHunger){
                Hunger = MaxHunger;
            }
            else{
                Hunger += amount;
            }
            break;

            default:
            Debug.Log("GainRessources() -> something fucked up");
            break;
        }
    }

    public void LooseRessource(Resource TryedResource, float amount)
    {
        switch (TryedResource)
        {
            case Resource.Health:
                Health -= amount;
                if(Health <= 0){
                    Debug.Log("no more Health");
                    //TODO: call a die function some way
                }
            break;

            case Resource.Hunger:
                Hunger -= amount;
                if(Hunger <= 0){
                    Debug.Log("no more stamina");
                    //TODO: call a die function some way
                }
            break;

            default:
            Debug.Log("LooseRessources() -> something fucked up");
            break;
        }
    }
    #endregion

    #region Unity Function
        private void Awake() {
            _health = MaxHealth;
            _hunger = MaxHunger;
        }

        private void Update() {
            //Decrease Hunger over time X units/seconds
            LooseRessource(Resource.Hunger, AmountOfHungerLoosePerSeconds * Time.deltaTime);
        }
    #endregion
}
