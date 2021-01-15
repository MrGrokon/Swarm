using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Attack))]

public class PlayerFieldOfView : Editor
{
    private void OnSceneGUI()
    {
        Attack AD = (Attack)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(AD.transform.position, Vector3.up, Vector3.forward, 360, AD.viewRadius);
        Vector3 viewAngleA = AD.DirFromAngle(-AD.viewAngle / 2, false);
        Vector3 viewAngleB = AD.DirFromAngle(AD.viewAngle / 2, false);
      
        Handles.DrawLine(AD.transform.position, AD.transform.position + viewAngleA * AD.viewRadius);
        Handles.DrawLine(AD.transform.position, AD.transform.position + viewAngleB * AD.viewRadius);
    }
}
