using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDetection : MonoBehaviour
{
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    public LayerMask targetMask;

    public LayerMask obstacleMask;
    public Transform validTarget;
    public Collider[] targetsInViewRadius = new Collider[0];

    public Transform FindVisibleTargets() //Repérage des cibles à portée
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
            validTarget = null;
        }

        return validTarget;
    }
    
    public Vector3 DirFromAngle(float  angleInDegrees, bool angleIsGlobal)  //Créer une direction depuis un angle, uniquement utilisée dans les scripts éditeur
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0,Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
