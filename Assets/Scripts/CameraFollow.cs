using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject plane;
    // private PlaneScript planeScript;

    private void Awake()
    {
        // planeScript = FindObjectOfType<PlaneScript>();
    }

    void Start()
    {
        // Vector3 objectPosition = plane.transform.position;
        // Vector3 objectWorldPosition = Camera.main.ScreenToWorldPoint(objectPosition);
        // Vector3 objectWorldPosition = Camera.main.ScreenToWorldPoint(objectPosition);
        // float objectX = objectWorldPosition.x;
        // Debug.Log(objectX);
        // transform.position = new Vector2(plane.transform.position.x, transform.position.y);
    }

    void Update()
    {
        // Debug.Log(plane.transform.position.x);
        // Vector3 objectPosition = plane.transform.position;
        // Vector3 objectWorldPosition = Camera.main.ScreenToWorldPoint(objectPosition);
        // Debug.Log(objectWorldPosition.x + "\t" + gameObject.transform.position.x);
        // transform.position = new Vector3(objectWorldPosition.x, 0f, -10f);
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + 1f, 0f, Camera.main.transform.position.z);
    }

}