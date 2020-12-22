using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseEmitter : MonoBehaviour
{
    public float noiseForce;

    public float maxNoiseForce;

    // Update is called once per frame
    void Update()
    {
        noiseForce = Mathf.Clamp(noiseForce, 0, maxNoiseForce);
    }
}
