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

    public void CheckAllActionsInRange()
    {
        CreatureAction_Interface.CreatureAction MyAction = _actionInterface.MyAction;
        GameObject[] CreatureOrderedByDistance = CreatureManager.Instance.GetAllCreatures().OrderBy(x => Vector3.Distance(x.transform.position, this.transform.position)).ToArray<GameObject>();
        foreach (var _nb in CreatureOrderedByDistance)
        {
            if (Vector3.Distance(this.transform.position, _nb.transform.position) <= RangeOfInfluence)
            {
                Debug.DrawLine(this.transform.position, _nb.transform.position, Color.magenta);
                CreatureAction_Interface.CreatureAction Nb_Action = _nb.GetComponent<CreatureAction_Interface>().MyAction;
                if (CreatureAction_Interface.Is_A_PriorTo_B(MyAction, Nb_Action))
                {
                    _actionInterface.ChangeCreatureAction(Nb_Action);
                }
            }
            else
            {
                break;
            }
        }
    }
}
