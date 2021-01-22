using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementDetector : MonoBehaviour
{
    private ParticleSystem PS_Leaf;
    private Animator _Animator;

    private void Start() {
        PS_Leaf = this.GetComponentInChildren<ParticleSystem>();
        _Animator = this.GetComponent<Animator>();
        if(PS_Leaf != null && _Animator != null){
            Debug.Log("PS or Animator isn't set up");
        }
    }

    private void OnTriggerEnter(Collider col) {
        if(col.tag == "Player" || col.tag == "Prey"){
            Debug.Log("Something enter into bush");
            PS_Leaf.Play();
            _Animator.SetTrigger("IsShaken");
        }
    }
}
