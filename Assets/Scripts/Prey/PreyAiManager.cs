using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class PreyAiManager : MonoBehaviour
{
    public enum PreyStates
    {
        Roam,
        LookingForSomething,
        Flee
    }
    [Header("Basic AI Parameters")]

    [Range(1f, 3f)]
    [SerializeField] private float ReachingDistance = 1.5f; 
    public PreyStates MyState;
    [SerializeField] PreyProfile MyProfile;

    private NavMeshAgent _nm_Agent;
    private AiDetection myDetector;
    private AiSoundDetection mySonorDetection;

    private void Awake()
    {
        _nm_Agent = GetComponent<NavMeshAgent>();
        myDetector = GetComponent<AiDetection>();
        mySonorDetection = GetComponent<AiSoundDetection>();
        if(MyProfile == null){
            Debug.Log("Critical Error: Prey Profile not found");
        }
        ChangeState(PreyStates.Roam);
    }

    private void Update()
    {
        if(_nm_Agent.remainingDistance <= ReachingDistance){
            Debug.Log("Prey reached his destination");
            //Do things when i reach my Position
            switch(MyState){
                case PreyStates.Flee:
                _nm_Agent.SetDestination(GetRandomRoamingPosition());
                ChangeState(PreyStates.Roam);
                break;

                case PreyStates.LookingForSomething:
                _nm_Agent.SetDestination(GetRandomRoamingPosition());
                ChangeState(PreyStates.Roam);
                break;
                
                case PreyStates.Roam:
                _nm_Agent.SetDestination(GetRandomRoamingPosition());
                ChangeState(PreyStates.Roam);
                break;
            }
        }

        if (myDetector.FindVisibleTargets() || mySonorDetection.FindVisibleTargets())
        {
            //If i found an Enemy
            Debug.Log("Prey spot the player");
            ChangeState(PreyStates.Flee);
            Vector3 FleeMotion = (Objects.Instance.Alpha.transform.position - transform.position)*-1;
            _nm_Agent.SetDestination(FleeMotion);
        }
    }

    public void ChangeState(PreyStates _state){
        if(MyState != _state){
            Debug.Log("ChangeState to " + _state);
            Change_NMA_Properties(_state);

        }
    }
    
    public void CheckOutFor(string _ressources){
        switch (_ressources){
            case "Food":
                ChangeState(PreyStates.LookingForSomething);
                _nm_Agent.SetDestination(Objects.Instance.GetCloserRessources(Objects.ObjectType.FoodSource, this.gameObject));
                //_nm_Agent.SetDestination(Objects.Instance.)
            break;

            case "Water":
                ChangeState(PreyStates.LookingForSomething);
                _nm_Agent.SetDestination(Objects.Instance.GetCloserRessources(Objects.ObjectType.WaterSource, this.gameObject));
                //Set the destination of my prey to the closer WaterSource
            break;

            default:
            Debug.Log("CheckOutFor() -> parameter wrong or incoherent");
            break;
        }
    }

    public bool IsAlreadyLooking(){
        if(MyState == PreyStates.LookingForSomething){
            return true;
        }
        return false;
    }

    public void Die()
    {
        //Destroy all tracks when the prey die
        //TODO: must be connected later to the HealthSysteme.
        foreach (var track in GetComponent<TracksCreatorOverTime>().PreyTracks)
        {
            Destroy(track);
        }

        GetComponent<TracksCreatorOverTime>().PreyTracks.Clear();
        Destroy(gameObject);
    }
    
    #region Low Level Functions

    private Vector3 GetRandomRoamingPosition(){
        //TODO: get a random position on the walkable NavMesh
        return Random.insideUnitSphere * 10f + this.transform.position;
    }

    private void Change_NMA_Properties(PreyStates _state){
        if(_state == PreyStates.Flee){
            _nm_Agent.speed = MyProfile.PreySpeed;
            _nm_Agent.acceleration = MyProfile.PreyAcceleraration;
        }
        else{
            _nm_Agent.speed = MyProfile.PreySpeed * MyProfile.SprintSpeedMultiplier;
            _nm_Agent.acceleration = MyProfile.PreyAcceleraration * MyProfile.SprintSpeedMultiplier;
        }
    }
    #endregion
}
