using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntelligenceInterface : MonoBehaviour
{
    public CreatureIntelligence MyIntelect;

    private void Start()
    {
        MyIntelect = GetComponent<CreatureIntelligence>();
    }

    private void SetTarget(GameObject Target)
    {
        
    }
}
