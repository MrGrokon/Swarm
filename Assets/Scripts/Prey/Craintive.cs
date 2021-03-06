﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class Craintive : PreyAiManager
{
    [SerializeField] private float scanInterval;
    [SerializeField] private float scanTime;
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
        
        //InvokeRepeating("Scan", 0, scanInterval);
        
    }

    private void Update()
    {
        ManageTimer();
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

        if(Vector3.Distance(_nm_Agent.destination, transform.position) <= ReachingDistance){
            //Debug.Log("Prey reached his destination");
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
                
                break;
                
                case PreyStates.Scan:
                    transform.Rotate(Vector3.up * (360 / scanTime) * Time.deltaTime);
                    break;
            }
        }

        if (myDetector.FindVisibleTargets() || mySonorDetection.FindVisibleTargets())
        {
            if (MyState != PreyStates.Flee ||
                Vector3.Distance(_nm_Agent.destination, transform.position) <= ReachingDistance)
            {
                ChangeState(PreyStates.Flee);
            }
           
        }
        else if (!myDetector.FindVisibleTargets() && MyState == PreyStates.Flee ||
                 !mySonorDetection.FindVisibleTargets() && MyState == PreyStates.Flee)
        {
            if (actualFleeTime <= 0)
            {
                _nm_Agent.SetDestination(GetRandomRoamingPosition());
                _animator.SetBool("IsRunning", false);
                Dust_PS.Stop();
                ChangeState(PreyStates.Roam);
            }
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
                //If i found an Enemy
                Debug.Log("Prey spot the player");

                //TODO: Test au moment de la detection, selon les behavior a mettre en place:
                //  -chercher à se cacher
                //  -fuire vers le reste de la meute
                //  -...

                _animator.SetBool("IsRunning", true);
                Dust_PS.Play();
                //ce vector pointe parfois dans la direction du joueur, ce qui implique que le joueur peu la toucher sur son chemin de fuite
                Vector3 FleeMotion = (Objects.Instance.Alpha.transform.position - this.transform.position).normalized * -5;
                NavMesh.SamplePosition(FleeMotion, out NavMeshHit hit, 1f, 1);
                Vector3 randomPositionInsideSphere = hit.position + Random.insideUnitSphere * 5f;
                if (_nm_Agent.CalculatePath(hit.position, new NavMeshPath()))
                {
                    _nm_Agent.SetDestination(hit.position);
                }
                else
                {
                    _nm_Agent.SetDestination(transform.position);
                }
                
                print("destination : " +_nm_Agent.destination);
                actualFleeTime = fleeTime;

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

    private void Scan()
    {
        if (MyState == PreyStates.Roam)
        {
            _nm_Agent.isStopped = true;
            ChangeState(PreyStates.Scan);
            StartCoroutine(ScanWait(3));
        }
            
    }

    IEnumerator ScanWait(int scanTime)
    {
        yield return new WaitForSeconds(scanTime);
        _nm_Agent.isStopped = false;
        ChangeState(PreyStates.Roam);
    }
    
    #region Low Level Functions

    private Vector3 GetRandomRoamingPosition(){
        //TODO: get a random position on the walkable NavMesh
        Vector3 _randomPos = Random.insideUnitSphere * randomRadius + this.transform.position;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_nm_Agent.destination, 2f);
    }

    private void ManageTimer()
    {
        if (actualFleeTime > 0)
        {
            actualFleeTime -= 1 * Time.deltaTime;
        }
    }
}
