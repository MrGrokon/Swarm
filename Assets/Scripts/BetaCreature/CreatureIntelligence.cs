using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;    WTF is that ?
using UnityEngine;
using UnityEngine.AI;

public class CreatureIntelligence : MonoBehaviour
{
    public enum CreatureState{Follow, Attack, InFormation, Static};

    [HideInInspector]
    public Vector3 Target;
    public CreatureState MyState;
    [Range(0.05f, 1f)]
    public float AI_ReachingMargin = 0.2f;

    private NavMeshAgent _nm_Agent;

    #region Unity Functions
        private void Start() {
            _nm_Agent = this.GetComponent<NavMeshAgent>();
            //ChangeCreatureState(CreatureState.Follow);
            _nm_Agent.SetDestination(RandomPositionAroundAlpha());

            //Ajoute les créatures préexistante au pack
            PackManager.packInstance.Add_PackMember(this.gameObject);
        }

        private void Update() {
            #region debug
            Debug.DrawLine(this.transform.position, _nm_Agent.destination, Color.red);
            #endregion

            if(MyState == CreatureState.InFormation ){
                if(Target != Vector3.zero){
                    _nm_Agent.destination = Target;
                }
                else{
                    Debug.Log("Creature InFormation but Target Undefined");
                    ChangeCreatureState(CreatureState.Follow);
                }
            }
            else{
                if(_nm_Agent.remainingDistance <= AI_ReachingMargin){
                    Debug.Log(this.name + " Reached his target");
                    switch(MyState){
                        case CreatureState.Follow:
                        Debug.Log("ca devrait marche");
                        ChangeCreatureState(CreatureState.Follow);
                        break;

                        default:
                        Debug.Log("CreatureInteligence State incoherent");
                        break;
                    }
                }
            }
        }
    #endregion
    
    #region Data Managing Functions
        
        public void ChangeCreatureState(CreatureState _state){
                if(_state == CreatureState.Follow){
                    _nm_Agent.SetDestination(RandomPositionAroundAlpha());
                }
                /*switch(_state){
                    case CreatureState.Attack:
                    MyState = _state;
                    break;

                    case CreatureState.Follow:
                    break;

                    default:
                    Debug.Log("Error ChangeCreatureState() value Incorrect");
                    break;
                }*/
        }

    #endregion

    #region  Low Level Function

        private Vector3 RandomPositionAroundAlpha(float OptionnalDistanceRange = 5f){
            Vector3 RandomPos = Random.insideUnitCircle;
            RandomPos.z = RandomPos.y;
            RandomPos.y = 0;
            RandomPos *= OptionnalDistanceRange;
            RandomPos += Objects.Instance.Alpha.transform.position;

            return RandomPos;
        }
    #endregion
}
