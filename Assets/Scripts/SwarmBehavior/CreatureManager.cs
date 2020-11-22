using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class CreatureManager : MonoBehaviour
{
    static public CreatureManager Instance;
    public GameObject MasterCreature;
    [SerializeField]
    private List<GameObject> SwarmCreatures = new List<GameObject>();

    private void Awake()
    {
        #region Singleton Instance
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        #endregion
    }

    #region Creature Managing Functions
    public void AddCreature(GameObject _creature)
    {
        if (SwarmCreatures.Contains(_creature) == false)
        {
            SwarmCreatures.Add(_creature);
        }
    }

    public void RemoveCreature(GameObject _creature)
    {
        if (SwarmCreatures.Contains(_creature))
        {
            SwarmCreatures.Remove(_creature);
        }
    }

    public GameObject[] GetAllCreatures()
    {
        return SwarmCreatures.ToArray();
    }
    #endregion

    #region Creature Master Related
       /*public void GetCenterOfMass()
       {

       }*/
    #endregion

    #region Low Level Functions
    /*private Vector3 GetLimitOnAxis(Vector3 axis, bool _max)
    {
        //return the highest or lower cell position on a defined axis
        if (Application.isPlaying == true)
        {
            if (axis == Vector3.right || axis == Vector3.left)
            {
                //axis == X
                GameObject[] Ordered_Creatures = GetAllCreatures().OrderBy(_crea => _crea.transform.position.x).ToArray();
                if (_max)
                {
                    int MaxArraySize = Ordered_Creatures.Length;
                    return Ordered_Creatures[MaxArraySize - 1].transform.position;
                }
                else
                {
                    return Ordered_Creatures[0].transform.position;
                }
            }
            else if (axis == Vector3.up || axis == Vector3.down)
            {
                //axis == Y
                GameObject[] OrderedCreatures = GetAllCreatures().OrderBy(_crea => _crea.transform.position.y).ToArray();
                if (_max)
                {
                    int MaxArraySize = OrderedCreatures.Length;
                    return OrderedCreatures[MaxArraySize - 1].transform.position;
                }
                else
                {
                    return OrderedCreatures[0].transform.position;
                }
            }
            else if (axis == Vector3.forward || axis == Vector3.back)
            {
                //axis == Z
                GameObject[] Ordered_Creatures = GetAllCreatures().OrderBy(_crea => _crea.transform.position.z).ToArray();
                if (_max)
                {
                    int MaxArraySize = Ordered_Creatures.Length;
                    return Ordered_Creatures[MaxArraySize - 1].transform.position;
                }
                else
                {
                    return Ordered_Creatures[0].transform.position;
                }
            }
        }
        return Vector3.zero;
    }*/
    #endregion
}
