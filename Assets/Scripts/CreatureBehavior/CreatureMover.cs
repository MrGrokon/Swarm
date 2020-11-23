using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureMover : MonoBehaviour
{
    public float CreatureSpeed = 50f;

    private Creature_CopyCatMechanism _coppyCat;
    private Rigidbody _Rb;

    private void Awake()
    {
        _coppyCat = this.GetComponent<Creature_CopyCatMechanism>();
        _Rb = this.GetComponent<Rigidbody>();
    }

    public void Move(Vector3 DirOfMotion)
    {
        if(this.gameObject == CreatureManager.Instance.MasterCreature)
        {
            Debug.DrawRay(this.transform.position, DirOfMotion*3, Color.yellow);
            _Rb.AddForce(DirOfMotion * CreatureSpeed);
        }
        else
        {
            //le neigbourg le plus proche dans la direction du joystick 
            //listOfNeighourg[0] -> pourrais etre le this.gameObject
            //c'est pour ca que j'ai choisi de faire le ListOfNeigbourg[1]
            
            //Debug.Log( this.name +" je bouge vers voisin "+ _coppyCat.GetListOfNeigbourg(DirOfMotion)[1].name);

            //fo trouver un moyen de recupérer le voisin avec l'angle qui match le plus vers joystickDir
            //Vector3 MotionDir = ( (_coppyCat.GetListOfNeigbourg(DirOfMotion)[1].transform.position + DirOfMotion) - this.transform.position ).normalized;
            
            GameObject _actualLeader = CreatureManager.Instance.GetLeaderDynamically(DirOfMotion);
            //Ajout d'un test de distance entre this et le master pour eviter de lock le systeme
            if(Vector3.Distance(this.transform.position, _actualLeader.transform.position) > 1.5f){
                Vector3 MotionDir = (_actualLeader.transform.position - this.transform.position).normalized;
                Debug.DrawRay(this.transform.position, MotionDir, Color.green);
                _Rb.AddForce(MotionDir * CreatureSpeed);
            }
            else{
                Debug.DrawRay(this.transform.position, (_actualLeader.transform.position - this.transform.position).normalized, Color.white);
            }
            
            
        }
    }
}
