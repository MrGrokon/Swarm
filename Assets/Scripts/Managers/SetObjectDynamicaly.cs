using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectDynamicaly : MonoBehaviour
{
    [SerializeField]
    private Objects.ObjectType MyType;

    private void Start() {
        Objects.Instance.AddAnObject(MyType, this.gameObject);
    }
}
