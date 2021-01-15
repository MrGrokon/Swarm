using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyLife : MonoBehaviour
{
    [SerializeField] private int lifePoint;

    // Update is called once per frame
    void Update()
    {
        if (lifePoint <= 0)
        {
            PreyAiManager manager = GetComponent(typeof(PreyAiManager)) as PreyAiManager;
            manager.Die();
        }
    }

    public void ApplyDammage(int dmg)
    {
        lifePoint -= dmg;
    }

    public void InstantKill()
    {
        lifePoint = 0;
    }
}
