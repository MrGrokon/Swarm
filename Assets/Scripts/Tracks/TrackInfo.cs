using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackInfo : MonoBehaviour
{
    [Header("Global parameters")]
    [SerializeField] private float[] anglesByFreshnessLevel;
    [SerializeField] private float[] distanceByFreshnessLevel;

    [Header("Local parameters")]
    public float actualAngle;

    public float actualDistance;

    
    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)  //Créer une direction depuis un angle, uniquement utilisée dans les scripts éditeur
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(actualAngle * Mathf.Deg2Rad), 0,Mathf.Cos(actualAngle * Mathf.Deg2Rad));
    }
}
