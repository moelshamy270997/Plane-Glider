using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FuelManager : MonoBehaviour
{
    public PlaneScript p;
    public float maxFuel = 100; // Maximum fuel capacity
    public float fuelDepletionRate = 10; // Rate at which fuel depletes
    public TextMeshProUGUI fuelText; // Reference to the fuel text component

    private float currentFuel; // Current fuel level
    public HealthBar healthBar;



    private void Start()
    {

        currentFuel = maxFuel;
        healthBar.SetMaxHealth(maxFuel);
    }

    private void Update()
    {
        if (p.isBoosting())
        {
            UpdateFuel();
        }
    }
    private void UpdateFuel()
    {
        healthBar.SetHealth(currentFuel);
        // Update the fuel level
        currentFuel -= fuelDepletionRate * Time.deltaTime;
        currentFuel = Mathf.Clamp(currentFuel, 0f, maxFuel);

        // Update the fuel text
        if (currentFuel <= 0f)
        {
            
            fuelText.fontSize = 24;
            fuelText.text = "Empty";
            p.GameOverFunction();

        }
        else
        {
            fuelText.text = currentFuel.ToString("F0");
        }
    }

    public void RestoreFuel(float amount)
    {
        // Increase the fuel level by the specified amount
        currentFuel += amount;
        currentFuel = Mathf.Clamp(currentFuel, 0f, maxFuel);
        UpdateFuel();
    }


    public bool CanBoost()
    {
        // Check if there is enough fuel to boost
        return currentFuel > 0f;
    }
    public void IncreaseFuel()
    {
        currentFuel += 10;
    }
    public void ConsumeFuel(float amount)
    {
        // Reduce the fuel level by the given amount      
        currentFuel -= amount;
        currentFuel = Mathf.Clamp(currentFuel, 0f, maxFuel);


    }
}