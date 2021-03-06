﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Terrier : PreyAiManager
{
    [SerializeField] private Transform burrowTransform;
    #region Unity Fonction
    private void Awake()
    {
        _nm_Agent = this.GetComponent<NavMeshAgent>();
        myDetector = this.GetComponent<AiDetection>();
        mySonorDetection = this.GetComponent<AiSoundDetection>();
        _abs_Resc_Manager = this.GetComponent<AbstractedRessourcesManager>();
        _animator = this.GetComponent<Animator>();
        Dust_PS = this.GetComponentInChildren<ParticleSystem>();

        if(Dust_PS != null){
            Dust_PS.Stop();
        }
        else{
            Debug.Log("DustParticule not found");
        }
        if(_abs_Resc_Manager == null){
            Debug.Log("AbstractedRessourcesManager not found");
        }
        if(MyProfile == null){
            Debug.Log("Critical Error: Prey Profile not found");
        }
        else{
            ChangeState(PreyStates.Roam);
            //normalement change_Nma_Properties() est déja appeler dans changeState()
            Change_NMA_Properties(PreyStates.Roam);
        }
        
    }

    private void Update()
    {
        #region State Debbuging
        if(MyState == PreyStates.Flee){
            Debug.DrawLine(this.transform.position, _nm_Agent.destination, Color.red);
        }
        else if(MyState == PreyStates.LookingForWater || MyState == PreyStates.LookingForFood ){
            Debug.DrawLine(this.transform.position, _nm_Agent.destination, Color.green);
        }
        else if(MyState == PreyStates.Roam){
            Debug.DrawLine(this.transform.position, _nm_Agent.destination, Color.blue);
        }
        #endregion

        if(_nm_Agent.remainingDistance <= ReachingDistance){
            //Do things when i reach my Position
            switch(MyState){

                case PreyStates.LookingForWater:
                //TODO: rester quelques seconde en position le temps de remplir ses ressources
                _abs_Resc_Manager.RestoreRessources("Water");
                _nm_Agent.SetDestination(GetRandomRoamingPosition());
                ChangeState(PreyStates.Roam);
                break;
                
                case PreyStates.Roam:
                //TODO: générer proproment un nouveau point de roaming, si possible non randomS
                _nm_Agent.SetDestination(GetRandomRoamingPosition());
                ChangeState(PreyStates.Roam);
                break;
            }
        }

        if (myDetector.FindVisibleTargets() || mySonorDetection.FindVisibleTargets())
        {
            //If i found an Enemy
            Debug.Log("Prey spot the player");

            //TODO: Test au moment de la detection, selon les behavior a mettre en place:
            //  -chercher à se cacher
            //  -fuire vers le reste de la meute
            //  -...

            _animator.SetBool("IsRunning", true);
            Dust_PS.Play();
            ChangeState(PreyStates.Flee);
        }
        else if (!myDetector.FindVisibleTargets() && MyState == PreyStates.Flee ||
                 !mySonorDetection.FindVisibleTargets() && MyState == PreyStates.Flee)
        {
            _nm_Agent.SetDestination(GetRandomRoamingPosition());
            _animator.SetBool("IsRunning", false);
            Dust_PS.Stop();
            ChangeState(PreyStates.Roam);
        }
    }
    #endregion

    public void ChangeState(PreyStates _state){
        if(MyState != _state){
            Debug.Log("ChangeState to " + _state);
            MyState = _state;
            Change_NMA_Properties(_state);
            OnChangedState(_state);
        }
    }

    private void OnChangedState(PreyStates _state)
    {
        switch (_state)
        {
            case PreyStates.Flee:
                //ce vector pointe parfois dans la direction du joueur, ce qui implique que le joueur peu la toucher sur son chemin de fuite
                Vector3 FleeMotion = (Objects.Instance.Alpha.transform.position - this.transform.position) * -5;
                NavMesh.SamplePosition(FleeMotion, out NavMeshHit hit, 1f, 1);
                _nm_Agent.SetDestination(hit.position);
                break;
        }
    }
    
    public override void CheckOutFor(string _ressources){
        switch (_ressources){
            case "Food":
                ChangeState(PreyStates.Roam);
                //ChangeState(PreyStates.LookingForSomething);
                //_nm_Agent.SetDestination(Objects.Instance.GetCloserRessources(Objects.ObjectType.FoodSource, this.gameObject));
                //_nm_Agent.SetDestination(Objects.Instance.)
            break;

            case "Water":
                ChangeState(PreyStates.LookingForWater);
                _nm_Agent.SetDestination(Objects.Instance.GetCloserRessources(Objects.ObjectType.WaterSource, this.gameObject));
                //Set the destination of my prey to the closer WaterSource
            break;

            default:
            Debug.Log("CheckOutFor() -> parameter wrong or incoherent");
            break;
        }
    }

    public override bool IsAlreadyLooking(){
        if(MyState == PreyStates.LookingForWater || MyState == PreyStates.LookingForFood){
            return true;
        }
        return false;
    }

    public override void Die()
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
        Vector3 _randomPos = Random.insideUnitSphere * 10f + this.transform.position;
        NavMeshHit _hit;
        NavMesh.SamplePosition(_randomPos, out _hit, Mathf.Infinity, 1); // 1 == au mask d'area Walkable du navMash
        return _hit.position;
    
    }

    private void Change_NMA_Properties(PreyStates _state){
        if(_state == PreyStates.Flee){
            _nm_Agent.speed = MyProfile.PreySpeed * MyProfile.SprintSpeedMultiplier;
            _nm_Agent.acceleration = MyProfile.PreyAcceleraration * MyProfile.SprintSpeedMultiplier;
        }
        else{
            _nm_Agent.speed = MyProfile.PreySpeed ;
            _nm_Agent.acceleration = MyProfile.PreyAcceleraration;
        }
    }
    #endregion
}
