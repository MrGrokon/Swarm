using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyLife : MonoBehaviour
{
    [SerializeField] private int lifePoint;

    public void ApplyDammage(int dmg)
    {
        lifePoint -= dmg;
        var manager = GetComponent(typeof(PreyAiManager)) as PreyAiManager;
        manager.takeDammage = true;
    }

    private void Update()
    {
        if (lifePoint <= 0)
        {
            var manager = GetComponent(typeof(PreyAiManager)) as PreyAiManager;
            manager.Die();
        }
    }
}
