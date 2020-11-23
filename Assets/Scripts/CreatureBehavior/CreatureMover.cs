using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMover : MonoBehaviour
{
    public float CreatureSpeed = 50f;

    private CreatureAction_Interface _actionInterface;
    private Rigidbody _Rb;

    private void Awake()
    {
        _Rb = this.GetComponent<Rigidbody>();
    }

    public void Move(Vector3 DirOfMotion)
    {
        if(this.gameObject == CreatureManager.Instance.MasterCreature)
        {
        }
        else
        {
            //this.GetComponent<Rigidbody>().AddForce(DirOfMotion * CreatureSpeed);
        }
    }
}
