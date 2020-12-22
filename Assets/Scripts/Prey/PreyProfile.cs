using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyProfile : MonoBehaviour
{
    [Range(4f, 15f)]
    public float PreySpeed = 8f;
    [Range(1f, 4f)]
    public float SprintSpeedMultiplier = 2.5f;
    [Range(8f, 20f)]
    public float PreyAcceleraration = 8f;

    private void Awake() {
        //destroy this gameobject when placed in the scene
        //must be referenced into PreyAIManagerScripts
        Destroy(this.gameObject);
    }
}
