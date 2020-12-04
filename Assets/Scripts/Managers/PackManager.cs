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
        Pack_Member.Add(creature);
    }

    public void Remove_PackMember(GameObject creature)
    {
        Pack_Member.Remove(creature);
        Destroy(creature);
    }

    public void SetFormationPoint()
    {
        
    }

    public int GetPackLenght()
    {
        return Pack_Member.Count;
    }
    
}
