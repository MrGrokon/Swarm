﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class PreyAiManager : MonoBehaviour
{
    public enum PreyStates
    {
        Roam,
        LookingForWater,
        LookingForFood,
        Waiting,
        Flee,
        Scan
    }
    
    [Header("Basic AI Parameters")]
    [Range(1f, 3f)]
    public float ReachingDistance = 1.5f; 
    public PreyStates MyState;
    public PreyProfile MyProfile;

    public NavMeshAgent _nm_Agent;
    public AiDetection myDetector;
    public AiSoundDetection mySonorDetection;
    public AbstractedRessourcesManager _abs_Resc_Manager;
    public Animator _animator;
    public ParticleSystem Dust_PS;
    public bool takeDammage;
    public float randomRadius;

    [Range(1f, 10f)]
    public float TimeToWaitForAbstractedRessources = 3f;
    public float _timePassed = 0f;

    public float fleeTime;
    public float actualFleeTime;

    public virtual void Die()
    {
        
    }

    public virtual bool IsAlreadyLooking()
    {
        return false;
    }

    public virtual void CheckOutFor(string type)
    {
        
    }
    
}
