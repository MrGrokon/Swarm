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

    public float MaxSwarmDistanceToGetMedian = -1f;

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

    public GameObject[] GetAllCreatures(float OptionalMaxDistance = -1f)
    {
        if(OptionalMaxDistance >0f){
            List<GameObject> TempTab = new List<GameObject>();
            foreach(var crea in SwarmCreatures){
                //le referenciel du calcul ne devrait pas forcement etre la MasterCreature, mais je ne vois pas de meilleur facon de le gerer de suite
                if(Vector3.Distance(MasterCreature.transform.position, crea.transform.position) <= OptionalMaxDistance){
                    TempTab.Add(crea.gameObject);
                }
            }
            return TempTab.ToArray();
        }
        return SwarmCreatures.ToArray();
    }
    #endregion

    #region Creature Master Related
       public Vector3 GetCenterOfMass()
       {
           Vector3 CenterOfMass = Vector3.zero;
           CenterOfMass += GetLimitOnAxis(Vector3.right, true);
           CenterOfMass += GetLimitOnAxis(Vector3.right, false);
           CenterOfMass += GetLimitOnAxis(Vector3.up, true);
           CenterOfMass += GetLimitOnAxis(Vector3.up, false);
           CenterOfMass += GetLimitOnAxis(Vector3.forward, true);
           CenterOfMass += GetLimitOnAxis(Vector3.forward, false);

           CenterOfMass = CenterOfMass/6;
           return CenterOfMass;
       }

       public GameObject GetLeaderDynamically(Vector3 JoystickDirection, int NmbOfCellAveraged = 3){
           GameObject[] Cells_orderedByAngle = GetAllCreatures(MaxSwarmDistanceToGetMedian).OrderBy(x => Vector3.Angle(JoystickDirection, x.transform.position - GetCenterOfMass())).ToArray<GameObject>();
            GameObject FarestCellOfAngle = Cells_orderedByAngle[0];
            for (int i = 0; i < NmbOfCellAveraged; i++)
            {
                if(Vector3.Distance(GetCenterOfMass(), Cells_orderedByAngle[i].transform.position) > Vector3.Distance(GetCenterOfMass(), FarestCellOfAngle.transform.position)){
                    FarestCellOfAngle = Cells_orderedByAngle[i];
                }
            }
            MasterCreature = FarestCellOfAngle;
            return FarestCellOfAngle;
       }
    #endregion

    #region Low Level Functions
    private Vector3 GetLimitOnAxis(Vector3 axis, bool _max)
    {
        //return the highest or lower cell position on a defined axis
        if (Application.isPlaying == true)
        {
            if (axis == Vector3.right || axis == Vector3.left)
            {
                //axis == X
                GameObject[] Ordered_Creatures = GetAllCreatures(MaxSwarmDistanceToGetMedian).OrderBy(_crea => _crea.transform.position.x).ToArray();
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
                GameObject[] OrderedCreatures = GetAllCreatures(MaxSwarmDistanceToGetMedian).OrderBy(_crea => _crea.transform.position.y).ToArray();
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
                GameObject[] Ordered_Creatures = GetAllCreatures(MaxSwarmDistanceToGetMedian).OrderBy(_crea => _crea.transform.position.z).ToArray();
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
    }
    #endregion
}
