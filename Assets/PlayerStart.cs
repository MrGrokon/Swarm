using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    [SerializeField] private GameObject playerGroup;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerGroup, transform.position, Quaternion.identity);
    }

}
