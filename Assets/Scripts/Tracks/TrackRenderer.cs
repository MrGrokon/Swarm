using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackRenderer : MonoBehaviour
{
    [Header("General Parameters")]
    public GameObject PreyRelated;
    public int MyTrackIndex;

    [Header("Display Parameters")]
    public float DistanceToPoint = 2f;
    [Range(1f, 10f)]
    public float TimeToBeDisplayed = 5f;
    private float TimePassed = 0f;
    private bool IsDisplayed = false;

    private LineRenderer _Line;

    #region Unity Functions
    void Start()
    {
        _Line = this.transform.GetChild(1).GetComponent<LineRenderer>();
        if(_Line == null){
            _Line.enabled = false;
            Debug.Log("Error: _LineRenderer not defined for " + this.name + " child");
            
        }
    }

    private void Update() {
        if(IsDisplayed == true){
            TimePassed += Time.deltaTime;
            if(TimePassed >= TimeToBeDisplayed){
                EraseTrail();
            }
        }
    }
    #endregion

    public void UseTrack(){
        Debug.Log("I UsedTrack()");
        IsDisplayed = true;
        DrawLineToward(GetNextTrack());
    }

    private Vector3 GetNextTrack(){
        //Get the value of next track or the prey
        GameObject _target;
        TracksCreatorOverTime _prey_trackCreator = PreyRelated.GetComponent<TracksCreatorOverTime>();
        if(_prey_trackCreator.PreyTracks.Count == MyTrackIndex+1){
            Debug.Log("No more track higher than me");
            _target = PreyRelated;
        }
        else{
            _target = _prey_trackCreator.GetTrackAtIndex(MyTrackIndex + 1);
        }
        return _target.transform.position;
    }

    #region Trail Displayer
    private void DrawLineToward(Vector3 PositionTargeted){
        //drawn the track Info toward the next target or prey
        Debug.DrawLine(this.transform.position, PositionTargeted, Color.magenta);
        #region track info by line renderer
        _Line.enabled = true;
        // _nextPos not right but Debug.drawnLine working pretty well, to be solved later
        Vector3 _nextPos = (this.transform.position - PositionTargeted ) * DistanceToPoint;
        _Line.SetPosition(0, this.transform.position);
        _Line.SetPosition(1, _nextPos);
        #endregion
        //TODO: Theo changes
    }

    private void EraseTrail(){
        IsDisplayed = false;
        _Line.enabled = false;
        TimePassed =0f;
    }
    #endregion
}
