using System;
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

        if (InputTester.inputInstance._playerInputs.Actions.ChangeCamera.triggered)
        {
            ChangeCamera();
        }
    }

    private void Reset()
    {
        SceneManager.LoadScene(0);
    }

    private void ChangeCamera()
    {
        Cameras[cameraNumber].SetActive(false);
        
        cameraNumber++;
        if (cameraNumber < 0)
        {
            cameraNumber = Cameras.Count - 1;
        }
        else if (cameraNumber > Cameras.Count - 1)
            cameraNumber = 0;
        Cameras[cameraNumber].SetActive(true);
        CameraRotate.cameraInstance.camera = Cameras[cameraNumber].GetComponentInChildren<CinemachineFreeLook>();
    }
}
