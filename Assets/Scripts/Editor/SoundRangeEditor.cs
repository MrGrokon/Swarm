using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(AiSoundDetection))]
public class SoundRangeEditor : Editor
{
    private void OnSceneGUI()
    {
        AiSoundDetection AD = (AiSoundDetection)target;
        Handles.color = Color.red;
        Handles.DrawWireArc(AD.transform.position, Vector3.up, Vector3.forward, 360, AD.GetViewRadius());
        Vector3 viewAngleA = AD.DirFromAngle(-AD.viewAngle / 2, false);
        Vector3 viewAngleB = AD.DirFromAngle(AD.viewAngle / 2, false);
      
        Handles.DrawLine(AD.transform.position, AD.transform.position + viewAngleA * AD.GetViewRadius());
        Handles.DrawLine(AD.transform.position, AD.transform.position + viewAngleB * AD.GetViewRadius());
    }
}
