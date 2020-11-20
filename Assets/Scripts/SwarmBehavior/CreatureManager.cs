using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureManager : MonoBehaviour
{
    static public CreatureManager Instance;
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
}
