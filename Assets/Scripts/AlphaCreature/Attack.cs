using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    [SerializeField] private Collider[] targetsInViewRadius;

    private RessourceManager _ressource;

    [Header("Attack Parameter")] public float viewRadius;
    [Range(0, 360)] public float viewAngle;

    public LayerMask targetMask;
    public Transform validTarget;

    public LayerMask obstacleMask;
    [SerializeField] private float dashJumpHeight;

    public float holdTime;
    [SerializeField] private float holdTimeToHeavyAttack;

    [Header("Cooldowns")] 
    [SerializeField] private float lightAttackCooldown;

    [SerializeField] private float heavyAttackCooldown;
    [SerializeField] private float actualLightAttackCooldown;

    [SerializeField] private float actualHeavyAttackCooldown;
    
    

    private void Start()
    {
        _ressource = this.GetComponent<RessourceManager>();
        actualHeavyAttackCooldown = heavyAttackCooldown;
        actualLightAttackCooldown = lightAttackCooldown;
    }

    #region Unity Function

    void Update()
    {
        AttackDetection();
        if (InputTester.inputInstance._playerInputs.Actions.Attack.ReadValue<float>() > 0)
        {
            holdTime += 1 * Time.deltaTime;
            if (holdTime >= holdTimeToHeavyAttack && actualHeavyAttackCooldown <= 0)
            {
                
                ApplyAttack("Heavy");
                actualHeavyAttackCooldown = heavyAttackCooldown;
                holdTime = 0;
            }
        }
        else
        {
            if (holdTime < holdTimeToHeavyAttack && holdTime > 0 && actualLightAttackCooldown <= 0)
            {
                
                ApplyAttack("Light");
                actualLightAttackCooldown = lightAttackCooldown;
            }
            holdTime = 0;
        }

        CooldownManager();
    }


    //Fonction pour déclenché l'attaque via un autre script
    public void DistantAttackCall(GameObject prey)
    {
        _ressource.GainRessource(RessourceManager.Resource.Hunger, 20f);
        PackManager.packInstance.gameObject.GetComponent<GeneratePrey>().listOfPrey.Remove(prey);
        prey.GetComponent<PreyAiManager>().Die();
        //GetComponent<PreySniffer>().ResetTrackerValue();

    }

    private Transform AttackDetection()
    {
        
        targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        if (targetsInViewRadius.Length > 0)
        {
            for (int i = 0; i < targetsInViewRadius.Length; i++)
            {
                Transform target = targetsInViewRadius[i].transform;
                Vector3 dirToTarget = (target.position - transform.position).normalized;

                if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
                {
                    float dstToTarget = Vector3.Distance(transform.position, target.position);
                    if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                    {
                        validTarget = target;
                    }

                }
            }
        }
        else
        {
            validTarget =  null;
        }

        return validTarget;
    }
    #endregion

    private void ApplyLightDammage(Transform obj)
    {
        print("Light Attack");
        if (obj)
        {
            _ressource.GainRessource(RessourceManager.Resource.Hunger, 20f);
            if(PackManager.packInstance.gameObject.GetComponent<GeneratePrey>())
                PackManager.packInstance.gameObject.GetComponent<GeneratePrey>().listOfPrey.Remove(obj.gameObject);
            //print(obj);
            obj.GetComponent<PreyLife>().ApplyDammage(1);
            
            //GetComponent<PreySniffer>().ResetTrackerValue();
        }
       
    }

    private void ApplyAttack(string attackType)
    {
        if(attackType == "Light")
            ApplyLightDammage(AttackDetection());
        else
        {
            HeavyAttack(AttackDetection());
        }
    }

    private void HeavyAttack(Transform obj)
    {
        print("Heavy Attack");
        if (obj)
        {
            _ressource.GainRessource(RessourceManager.Resource.Hunger, 20f);
            if(PackManager.packInstance.gameObject.GetComponent<GeneratePrey>())
                PackManager.packInstance.gameObject.GetComponent<GeneratePrey>().listOfPrey.Remove(obj.gameObject);
            GetComponent<Rigidbody>().MovePosition(obj.transform.position);
            print("Proie : " +obj);
            obj.GetComponent<PreyLife>().InstantKill(); 
        }
    }
    
    private float CalculateJumpSpeed(float jumpHeight, float gravity)
    {
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }

    private void CooldownManager()
    {
        actualLightAttackCooldown -= 1 * Time.deltaTime;
        actualHeavyAttackCooldown -= 1 * Time.deltaTime;
    }


    #region EditorFunction

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)  //Créer une direction depuis un angle, uniquement utilisée dans les scripts éditeur
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0,Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    #endregion
    
}
