using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntelligenceInterface : MonoBehaviour
{
    private CreatureIntelligence _MyIntelect;

    private void Awake()
    {
        _MyIntelect = this.GetComponent<CreatureIntelligence>();
        if(_MyIntelect == null){
            Debug.Log("Critical Error: CreatureIntel not found for " + this.name);
        }
    }

    #region SetTargets() Surdeffinitions

    public void SetTarget(GameObject _target)
    {
        _MyIntelect.Target = _target.transform.position;
    }

    public void SetTarget(Transform _target){
        _MyIntelect.Target = _target.position;
    }

    public void SetTarget(Vector3 _target){
        _MyIntelect.Target = _target;
    }

    #endregion
}
