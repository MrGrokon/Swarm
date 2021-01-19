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
        CheckPlayerSpeedIntensity();
    }

    private void CheckPlayerSpeedIntensity()
    {
        CreatureMover mover = GetComponent<CreatureMover>();
        if ((mover.speed * mover.speedMultiplier) / (mover.maxSpeed * mover.maxSpeedMultiplier) > 0 && (mover.speed * mover.speedMultiplier) / (mover.maxSpeed * mover.maxSpeedMultiplier) <= 0.66f)
        {
            noiseForce = 1;
        }
        else if((mover.speed * mover.speedMultiplier) / (mover.maxSpeed * mover.maxSpeedMultiplier) > 0.66f && (mover.speed * mover.speedMultiplier) / (mover.maxSpeed * mover.maxSpeedMultiplier) <= 1f)
        {
            noiseForce = 2;
        }
        /*else if((mover.speed * mover.speedMultiplier) / (mover.maxSpeed * mover.maxSpeedMultiplier) > 0.66f && (mover.speed * mover.speedMultiplier) / (mover.maxSpeed * mover.maxSpeedMultiplier) <= 1f)
        {
            noiseForce = 3;
        }*/
        else
        {
            noiseForce = 0;
        }
    }
}
