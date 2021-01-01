using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThridPersonCamera : MonoBehaviour
{

    private float distance;
    
    private Vector3 dollyDir;

    [SerializeField] private float minDistance;

    [SerializeField] private float maxDistance;

    [SerializeField] private float smooth;

    public Transform targetToLook;

    
    // Start is called before the first frame update
    void Start()
    {
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (targetToLook)
        {
            transform.position = targetToLook.position + (targetToLook.transform.right * offset.x) + (-targetToLook.transform.forward * offset.z);
        }*/
        Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDir * maxDistance);
        RaycastHit hit;
        if (Physics.Linecast(transform.parent.position, desiredCameraPos, out hit))
        {
            distance = Mathf.Clamp((hit.distance * 0.5f), minDistance, maxDistance);
        }
        else
        {
            distance = maxDistance;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
    }
}
