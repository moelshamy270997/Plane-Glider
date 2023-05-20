using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    // float speed = 0.5f;

    Rigidbody2D rb;
    [SerializeField] GameObject prefab;
    [SerializeField] Canvas canvas;
    bool movingUp = false;

    // Vector3 torque = new Vector3(0f, torqueStrength, 0f);

    void Start()
    {
        // StartCoroutine(SpawnObjects());

        rb = gameObject.GetComponent<Rigidbody2D>();

        // rb.AddForce(Vector2.up * 1f);
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(1f, 0f), ForceMode2D.Impulse);

        if (movingUp)
        {
            // Debug.Log(Camera.main.ViewportToWorldPoint(Vector2.one).y + "  " + gameObject.transform.position.y);
            if (gameObject.transform.position.y < 2f)
            {
                // rb.AddForce(new Vector2(0f, 0.2f), ForceMode2D.Impulse);
                // Debug.Log(gameObject.transform.localEulerAngles.z);
                // Torque(5f);
            } 
        }
        else
        {
            // rb.AddForce(new Vector2(0f, -2f), ForceMode2D.Impulse);
        }
        /*
        if (movingUp)
        {
            rb.AddForce(Vector2.up * 2f);
            rb.velocity = new Vector2(0.1f, 0.2f);
            rb.AddTorque(3f);
        }
        
        if (!movingUp && rb.angularVelocity > -10f)
        {
            rb.angularVelocity = -15f;
            // rb.AddForce(Vector2.down * 1f);
            // rb.AddTorque(-3f);
            // rb.AddTorque(-15f);
            Debug.Log(rb.angularVelocity);

        }
        */

        // rb.AddForce(Vector2.up * 0.5f);
        // rb.AddTorque(-5f);
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKey(KeyCode.Space))
        {
            movingUp = true;
            // Torque(5f);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            movingUp = false;
        }
    }

    void Torque(float value)
    {
        // Debug.Log(gameObject.transform.localEulerAngles.z);
        // if (value > 0f && gameObject.transform.localEulerAngles.z < 30f)
        // rb.AddTorque(value);
        // else // if (value < 0f && gameObject.transform.localEulerAngles.z > -30f)
        // rb.AddTorque(value);
    }

    IEnumerator SpawnObjects()
    {
        while (true)
        {
            GameObject spawnedObject = Instantiate(prefab, new Vector3(gameObject.transform.position.x, -200f, -10f), Quaternion.identity);
            spawnedObject.transform.SetParent(canvas.transform, false);
            yield return new WaitForSeconds(2f); // Wait for 2 seconds before spawning the next object
        }
    }
}
