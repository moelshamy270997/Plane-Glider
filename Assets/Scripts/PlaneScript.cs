using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    Rigidbody2D rb;
    bool movingUp = false;
    LevelOneAudioScript levelOneAudioScript;

    private bool gameOver = false;
    public bool GameOver
    {
        get { return gameOver; }
        set { gameOver = value; }
    }
    private bool cameraFollow = false;
    public bool CameraFollow
    {
        get { return cameraFollow; }
        set { cameraFollow = value; }
    }

    private void Awake()
    {
        levelOneAudioScript = GameObject.Find("AudioObject").GetComponent<LevelOneAudioScript>();
    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // rb.AddForce(new Vector2(1f, 0f), ForceMode2D.Impulse);
        /*
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
        */
        if (movingUp)
        {
            rb.AddForce(Vector2.up * 10f, ForceMode2D.Force);
            // rb.velocity = new Vector2(0.1f, 0.2f);
            // TorqueUp(3f);
        }
        else
        {
            rb.AddForce(Vector2.down * 10f, ForceMode2D.Force);
            // TorqueDown(-3f);
        }
        /*
        if (!movingUp && rb.angularVelocity > -10f)
        {
            // rb.angularVelocity = -15f;
            // rb.AddForce(Vector2.down * 1f);
            // rb.AddTorque(-3f);
            // rb.AddTorque(-15f);

        }
        */
        

        // rb.AddForce(Vector2.up * 0.5f);
        // rb.AddTorque(-5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                levelOneAudioScript.PlayJumpSFX();
                movingUp = true;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                movingUp = false;
            }
        }
        else
        {
            // TODO: Start new Game
            if (Input.GetKey(KeyCode.Space))
            {

            }
        }

        // TODO: Reset and move to main Scene
        if (Input.GetKey(KeyCode.R))
        {

        }
    }

    
    void TorqueUp(float value)
    {
        if (gameObject.transform.localEulerAngles.z < 20f)
            rb.AddTorque(value);
    }

    void TorqueDown(float value)
    {
        if (gameObject.transform.localEulerAngles.z > -20f)
            rb.AddTorque(value);
    }


    /*
    IEnumerator SpawnObjects()
    {
        while (true)
        {
            GameObject spawnedObject = Instantiate(prefab, new Vector3(gameObject.transform.position.x, -200f, -10f), Quaternion.identity);
            spawnedObject.transform.SetParent(canvas.transform, false);
            yield return new WaitForSeconds(2f); // Wait for 2 seconds before spawning the next object
        }
    }
    */

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") || collision.CompareTag("Ground") || collision.CompareTag("Animal"))
        {
            levelOneAudioScript.PlayHitFX();
            Debug.Log("Collision");
            // cameraFollow = true;
            rb.gravityScale = 1f;
            gameOver = true;
            GameOverFunction();
        }
        if (collision.CompareTag("PowerUp"))
        {
            // TODO: Power UP
        }

        if (collision.CompareTag("End"))
        {
            // TODO: Player Won the Game
        }
    }

    void GameOverFunction()
    {
        rb.AddForce(Vector2.down * 10f, ForceMode2D.Force);
    }
}
