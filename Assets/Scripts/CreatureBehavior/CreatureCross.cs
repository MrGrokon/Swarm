using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CreatureCross : MonoBehaviour
{
    [SerializeField] private List<GameObject> _chain;
    [SerializeField] private GameObject lastObjectOfTheChain;

    [SerializeField] private float minimalDistanceToChain;

    [SerializeField] private bool isChained;

    [SerializeField] private bool inputIsReleased = true;

    private Vector3 direction;
     // Update is called once per frame
    public void Update()
    {
        float FBvalue = InputTester.input_Instance.Inputs.Actions.BridgeFB.ReadValue<float>();
        float RLvalue = InputTester.input_Instance.Inputs.Actions.BridgeRL.ReadValue<float>();
        if ( FBvalue == 1f || RLvalue == 1f || FBvalue == -1f || RLvalue == -1f)
        {
            if (CreatureManager.Instance.MasterCreature && inputIsReleased)
            {
                Vector3 dir = new Vector3(-InputTester.input_Instance.Inputs.Actions.BridgeFB.ReadValue<float>(), 0, InputTester.input_Instance.Inputs.Actions.BridgeRL.ReadValue<float>());
                Debug.DrawRay(CreatureManager.Instance.MasterCreature.transform.position, dir * 10, Color.green);
                isChained = !isChained;
                inputIsReleased = false;
                direction = dir;
                CreatureManager.Instance.MasterCreature.GetComponent<Rigidbody>().isKinematic = true;
            }
            
        }
        else if(InputTester.input_Instance.Inputs.Actions.BridgeFB.ReadValue<float>() == 0 ||
                InputTester.input_Instance.Inputs.Actions.BridgeRL.ReadValue<float>() == 0)
        {
            inputIsReleased = true;
            CreatureManager.Instance.MasterCreature.GetComponent<Rigidbody>().isKinematic = false;
        }
        CheckChain(direction);
    }

    private void CheckChain(Vector3 dir)
    {
        if (isChained)
        {
            ChainObjects(dir);
        }
        else
        {
            if (_chain.Count > 0)
            {
                CreatureManager.Instance.MasterCreature.GetComponent<Rigidbody>().isKinematic = false;
                foreach (var creature in _chain)
                {
                    if(creature.GetComponent<CharacterJoint>())
                        Destroy(creature.GetComponent<CharacterJoint>());
                }
            }
        }
    }

    private void ChainObjects(Vector3 direction)
    {
        
        List<GameObject> Creatures = new List<GameObject>();
        foreach (var G in CreatureManager.Instance.GetAllCreatures())
        {
            if(G != CreatureManager.Instance.MasterCreature)
             Creatures.Add(G);
        }
        for (int i = 0;  i < Creatures.Count; i++)
        {
            GameObject creature = Creatures[i];
                if (!lastObjectOfTheChain)
                {
                    if (Vector3.Distance(creature.transform.position,
                        CreatureManager.Instance.MasterCreature.transform.position) > minimalDistanceToChain && !_chain.Contains(creature))
                    {
                        CreatureMover mover = creature.GetComponent<CreatureMover>();
                        Vector3 dir = CreatureManager.Instance.MasterCreature.transform.position - creature.transform.position;
                        creature.GetComponent<Rigidbody>().AddForce(dir * mover.CreatureSpeed);
                    }
                    else if(Vector3.Distance(creature.transform.position,
                        CreatureManager.Instance.MasterCreature.transform.position) <= minimalDistanceToChain || _chain.Contains(creature))
                    {
                        int I = i;
                        lastObjectOfTheChain = creature;
                        creature.transform.position = CreatureManager.Instance.MasterCreature.transform.position + direction * I;
                        creature.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        creature.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                        if (creature.GetComponent<CharacterJoint>())
                        {
                            CharacterJoint CJ = creature.AddComponent<CharacterJoint>();
                            CJ.connectedBody = lastObjectOfTheChain.GetComponent<Rigidbody>();
                        }
                        if(!_chain.Contains(creature))
                            _chain.Add(creature);
                    }
                }
                else
                {
                    if (Vector3.Distance(creature.transform.position,
                        lastObjectOfTheChain.transform.position) > minimalDistanceToChain && !_chain.Contains(creature))
                    {
                        CreatureMover mover = creature.GetComponent<CreatureMover>();
                        Vector3 dir = lastObjectOfTheChain.transform.position - creature.transform.position;
                        creature.GetComponent<Rigidbody>().AddForce(dir * mover.CreatureSpeed);
                    }
                    else if(Vector3.Distance(creature.transform.position,
                        lastObjectOfTheChain.transform.position) <= minimalDistanceToChain || _chain.Contains(creature))
                    {
                        int I = i;
                        creature.transform.position = CreatureManager.Instance.MasterCreature.transform.position + direction * (I + 1);
                        creature.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        creature.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                        if (creature.GetComponent<CharacterJoint>())
                        {
                            CharacterJoint CJ = creature.AddComponent<CharacterJoint>();
                            CJ.connectedBody = lastObjectOfTheChain.GetComponent<Rigidbody>();
                        }
                        lastObjectOfTheChain = creature;
                        if(!_chain.Contains(creature))
                            _chain.Add(creature);
                    }
                }
                
                
            
        }
    }
}
