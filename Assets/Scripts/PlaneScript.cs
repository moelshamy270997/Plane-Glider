using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class PlaneScript : MonoBehaviour
{
    Rigidbody2D rb;
    float fuelAmount = 20f;
    bool movingUp = false;

    public bool collied = false;
    float rotationSpeed = 2f;
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

    FuelManager fuelGauge;


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
            transform.rotation = Quaternion.Euler(0f, 0f, 38f);
        }
        else
        {
            rb.AddForce(Vector2.down * 10f, ForceMode2D.Force);
            transform.rotation = Quaternion.Euler(0f, 0f, -38);
            // TorqueDown(-3f);
        }
        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -5, 12.11f);
        transform.position = clampedPosition;
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }
    }




    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") || collision.CompareTag("Animal"))
        {
            levelOneAudioScript.PlayHitSFX();
            // rb.gravityScale = 1f;
            gameOver = true;
            GameOverFunction();
        }
        if (collision.CompareTag("PowerUp"))
        {
            fuelGauge = FindObjectOfType<FuelManager>();
            fuelGauge.RestoreFuel(fuelAmount);
            collision.gameObject.SetActive(false);
            levelOneAudioScript.PlayFuelSFX();
        }

        if (collision.CompareTag("End"))
        {
            gameOver = true;
            levelOneAudioScript.Stop();
            levelOneAudioScript.PlayWinSFX();

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            gameOver = true;
            levelOneAudioScript.PlayHitSFX();
        }
    }

    public void GameOverFunction()
    {
        rb.AddForce(Vector2.down * 10f, ForceMode2D.Force);
    }
    public bool isBoosting()
    {
        return movingUp;
    }
}
