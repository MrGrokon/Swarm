﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracksCreatorOverTime : MonoBehaviour
{
    public GameObject TrackPrefab;
    public float MinTimeToLeaveTrack = 5f, MaxTimeToLeaveTrack = 25f;

    //private List<GameObject> tracks = new List<GameObject>();    
    private float _timePassed = 0f, _timeToWait;

    public List<GameObject> preyTracks;

    #region Unity Functions
        private void Awake() {
            _timeToWait = Random.Range(MinTimeToLeaveTrack, MaxTimeToLeaveTrack);
        }

        private void Update() {
            if(_timePassed < _timeToWait){
                _timePassed += Time.deltaTime;
            }
            else{
                ResetTimer();
                CreateTrack();
            }
        }
    #endregion


    private void ResetTimer(){
        _timePassed = 0f;
        _timeToWait = Random.Range(MinTimeToLeaveTrack, MaxTimeToLeaveTrack);
    }

    public void CreateTrack()
    {
        GameObject _track = Instantiate(TrackPrefab, this.transform.position, Quaternion.identity);
        _track.GetComponent<DetectPlayer>().prey = this.gameObject;
        preyTracks.Add(_track);
        //tracks.Add(_track);
    }
}
