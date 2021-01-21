using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackRenderer : MonoBehaviour
{
    [Header("General Parameters")]
    public GameObject PreyRelated;
    public int MyTrackIndex;

    [Header("Display Parameters")]
    public bool DebugLineRenderer = false;
    public Gradient FreshnessGradient;
    public float DistanceToPoint = 4f;
    [Range(1f, 10f)]
    public float TimeToBeDisplayed = 5f;
    private float TimePassed = 0f;
    private bool IsDisplayed = false;
    

    [SerializeField] private GameObject lastPrevisuMesh;

    private Vector3 AngleA;
    private Vector3 AngleB;

    #region Unity Functions
    void Start()
    {

        GetComponentInChildren<MeshRenderer>().enabled = false;

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

    public void UseTrack(){  //Affichage de la ligne de rendu
        Debug.Log("I UsedTrack()");
        IsDisplayed = true;
        DrawLineToward(GetNextTrack());
    }

    private Vector3 GetNextTrack(){  //Obtention de la position de la prochaine traçe
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
    private void DrawLineToward(Vector3 PositionTargeted){  //Création de la ligne de traque
        //drawn the track Info toward the next target or prey
        Debug.DrawLine(this.transform.position, PositionTargeted, Color.magenta);

        //TODO: Theo changes
        CreateVisualMesh();
    }

    private void EraseTrail(){ 
        IsDisplayed = false;
        TimePassed = 0f;
    }

    private Color GetGradientColorOverFreshness(){  //Créer un gradient selon la fraicheur de la traçe et la distance
        float _value = Mathf.Lerp(0f, PreyRelated.GetComponent<TracksCreatorOverTime>().PreyTracks.Count, MyTrackIndex);
        _value = Mathf.Clamp(_value, 0f, 1f);
        return FreshnessGradient.Evaluate(_value);
    }
    #endregion

    private void CreateVisualMesh()  //Creation du mesh de visualisation, il ne s'agit là que d'une base qui n'est pas fonctionelle
    {
        
        Vector3[] vertices = new Vector3[3];
        Vector2[] uv = new Vector2[3];
        int[] triangles = new int[3];

        AngleA = GetComponent<TrackInfo>().DirFromAngle(GetComponent<TrackInfo>().actualAngle / 2, true);
        AngleB = new Vector3(-AngleA.x, AngleA.y, AngleA.z);
        
        
        vertices[0] = new Vector3(0,0);
        vertices[1] = AngleA * -DistanceToPoint;
        vertices[2] = AngleB * -DistanceToPoint;
        

        uv[0] = new Vector3(0,1);
        uv[1] = AngleA * -DistanceToPoint;
        uv[2] = AngleB * -DistanceToPoint;

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        Shader shader = Shader.Find("Standard");
        Material material = new Material(shader);
        material.color = GetGradientColorOverFreshness();

        if (!lastPrevisuMesh)
        {
            GameObject visuMesh = new GameObject("Visualization", typeof(MeshFilter), typeof(MeshRenderer));
            visuMesh.GetComponent<MeshFilter>().mesh = mesh;
            visuMesh.transform.localScale = new Vector3(1, 1, 1);
            visuMesh.transform.position = transform.position;
            visuMesh.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y + 180, 0);
            visuMesh.transform.parent = this.transform;
            visuMesh.GetComponent<Renderer>().material = material;
            lastPrevisuMesh = visuMesh;
        }
        else
        {
            Destroy(lastPrevisuMesh);
            lastPrevisuMesh = new GameObject("Visualization", typeof(MeshFilter), typeof(MeshRenderer));
            lastPrevisuMesh.GetComponent<MeshFilter>().mesh = mesh;
            lastPrevisuMesh.transform.localScale = new Vector3(1, 1, 1);
            lastPrevisuMesh.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y + 180, 0);
            lastPrevisuMesh.transform.position = transform.position;
            lastPrevisuMesh.transform.parent = this.transform;
            lastPrevisuMesh.GetComponent<Renderer>().material = material;
        }
        
        lastPrevisuMesh.transform.LookAt(GetNextTrack());
    }

}
