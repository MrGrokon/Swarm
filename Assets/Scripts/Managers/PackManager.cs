using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PackManager : MonoBehaviour
{
    public static PackManager packInstance;
    [SerializeField] private List<GameObject> Pack_Member;

    private void Awake()
    {
        if (packInstance == null)
        {
            packInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void Add_PackMember(GameObject creature)
    {
        if(Pack_Member.Contains(creature) == false){
            Pack_Member.Add(creature);
        }
    }

    public void Remove_PackMember(GameObject creature)
    {
        if(Pack_Member.Contains(creature)){
            Pack_Member.Remove(creature);
        }
    }

    public void SetFormationPoint()
    {
        Transform[] _temp = Objects.Instance.Alpha.GetComponent<PackOrderer>().formationPoints.ToArray();
        // better luck next time
        for (int i = 0; i < _temp.Length; i++)
        {
            Pack_Member[i].GetComponent<IntelligenceInterface>().SetTarget(_temp[i]);
        }
    }

    public void FreeAllBetas(){ //"Casse" la formation actuel
        foreach(var _beta in Pack_Member){
            CreatureIntelligence _intel = _beta.GetComponent<CreatureIntelligence>();
            _intel.Target = Vector3.zero;
            _intel.ChangeCreatureState(CreatureIntelligence.CreatureState.Follow);
        }
    }

    public int GetPackLenght()
    {
        return Pack_Member.Count;
    }
    
}
