using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    [SerializeField] GameObject groundPrefab;
    [SerializeField] Canvas canvas;
    List<GameObject> groundObjects = new List<GameObject>();
    GameObject[] obstaclesObjects;
    GameObject[] FuelObjects;
    [SerializeField] GameObject endObj;


    float speed = 2f;

    // PlaneScript planeScript;

    private void Awake()
    {
        // planeScript = FindObjectOfType<PlaneScript>();
    }

    void Start()
    {
        GameSetUp();
        obstaclesObjects = GameObject.FindGameObjectsWithTag("Obstacle");
        FuelObjects = GameObject.FindGameObjectsWithTag("PowerUp");
    }


    void Update()
    {
        GroundMovement();
        ObstacleMovement();
        FuelMovement();
        EndMovement();
    }

    void GameSetUp()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject obj = Instantiate(groundPrefab, new Vector3(807f * groundObjects.Count, -200f, -10f), Quaternion.identity);
            groundObjects.Add(obj);
            obj.transform.SetParent(canvas.transform, false);
        }
    }

    void GroundMovement()
    {
        foreach (GameObject obj in groundObjects)
            obj.transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void ObstacleMovement()
    {
        foreach (GameObject obj in obstaclesObjects)
            obj.transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void FuelMovement()
    {
        foreach (GameObject obj in FuelObjects)
            obj.transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void EndMovement()
    {
        endObj.transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
