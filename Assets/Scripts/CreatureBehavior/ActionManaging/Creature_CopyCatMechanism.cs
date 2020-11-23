using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class Creature_CopyCatMechanism : MonoBehaviour
{
    public float RangeOfInfluence = 5f;

    private CreatureAction_Interface _actionInterface;

    #region Unity Functions
    private void Awake()
    {
        _actionInterface = this.GetComponent<CreatureAction_Interface>();
    }

    private void Update()
    {
        CheckAllActionsInRange();
    }
    #endregion

    public GameObject[] GetListOfNeigbourg(){
        List<GameObject> nb_List = new List<GameObject>();
        GameObject[] CreatureOrderedByDistance = CreatureManager.Instance.GetAllCreatures().OrderBy(x => Vector3.Distance(x.transform.position, this.transform.position)).ToArray<GameObject>();
        foreach(var crea in CreatureOrderedByDistance){
            if(Vector3.Distance(this.transform.position, crea.transform.position) <= RangeOfInfluence){
                nb_List.Add(crea);
            }
            else{
                break;
            }
        }
        return nb_List.ToArray();
    }
    
    public GameObject[] GetListOfNeigbourg(Vector3 OptionalJoystickAngle){
        GameObject[] _Neigbours = GetListOfNeigbourg();
        _Neigbours.OrderBy(x => Vector3.Angle(OptionalJoystickAngle, x.transform.position - CreatureManager.Instance.GetCenterOfMass()));
        return _Neigbours;
    }

    public void CheckAllActionsInRange(){
        CreatureAction_Interface.CreatureAction _MyAction = _actionInterface.MyAction;
        GameObject[] _Neigbours = GetListOfNeigbourg();
        foreach(var _nb in _Neigbours){
            //Debug.DrawLine(this.transform.position, _nb.transform.position, Color.magenta);
            CreatureAction_Interface.CreatureAction _nb_Action = _nb.GetComponent<CreatureAction_Interface>().MyAction;
            if(CreatureAction_Interface.Is_A_PriorTo_B(_nb_Action, _MyAction)){
                _actionInterface.ChangeCreatureAction(_nb_Action);
            }
        }
    }

    /*public void CheckAllActionsInRange()
    {
        CreatureAction_Interface.CreatureAction _MyAction = _actionInterface.MyAction;
        GameObject[] CreatureOrderedByDistance = CreatureManager.Instance.GetAllCreatures().OrderBy(x => Vector3.Distance(x.transform.position, this.transform.position)).ToArray<GameObject>();
        foreach (var _nb in CreatureOrderedByDistance)
        {
            if (Vector3.Distance(this.transform.position, _nb.transform.position) <= RangeOfInfluence)
            {
                Debug.DrawLine(this.transform.position, _nb.transform.position, Color.magenta);
                CreatureAction_Interface.CreatureAction Nb_Action = _nb.GetComponent<CreatureAction_Interface>().MyAction;
                if (CreatureAction_Interface.Is_A_PriorTo_B(Nb_Action, _MyAction))
                {
                    //Debug.Log(this.name + " became " + Nb_Action +" from " + _nb.name);
                    _actionInterface.ChangeCreatureAction(Nb_Action);
                }
            }
            else
            {
                break;
            }
        }
    }*/
}
