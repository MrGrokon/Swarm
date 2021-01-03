using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrackOverTime : MonoBehaviour
{

    [SerializeField] private float timeToDestroy;

    private float actualTime;
    
    // Update is called once per frame
    void Update()
    {
        actualTime += 1 * Time.deltaTime;
        if (actualTime >= timeToDestroy)
        {
            var prey = GetComponent<TrackRenderer>().PreyRelated;
            prey.GetComponent<TracksCreatorOverTime>().PreyTracks.Remove(this.gameObject);
            Destroy(gameObject);
        }
    }
}
