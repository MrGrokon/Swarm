﻿using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> Cameras;
    [SerializeField] private int cameraNumber;

    // Update is called once per frame
    void Update()
    {
        if (InputTester.inputInstance._playerInputs.Actions.Reset.triggered)
        {
            Reset();
        }
    }

    private void Reset()
    {
        SceneManager.LoadScene(0);
    }

}
