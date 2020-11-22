using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera cameraHolder;
    [SerializeField] private CinemachineFreeLook freeCameraHolder;

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        cameraHolder.LookAt = CreatureManager.Instance.MasterCreature.transform;
        cameraHolder.Follow = CreatureManager.Instance.MasterCreature.transform;
        freeCameraHolder.LookAt = CreatureManager.Instance.MasterCreature.transform;
        freeCameraHolder.Follow = CreatureManager.Instance.MasterCreature.transform;
    }
}
