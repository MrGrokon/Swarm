using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private Transform[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InputTester.inputInstance._playerInputs.Actions.FirstPart.triggered)
        {
            SceneManager.LoadScene(0);
        }

        if (InputTester.inputInstance._playerInputs.Actions.SecondPart.triggered)
        {
            Objects.Instance.Alpha.transform.position = spawnPoints[1].position;
        }
        if (InputTester.inputInstance._playerInputs.Actions.ThirdPart.triggered)
        {
            Objects.Instance.Alpha.transform.position = spawnPoints[2].position;
        }
    }
}
