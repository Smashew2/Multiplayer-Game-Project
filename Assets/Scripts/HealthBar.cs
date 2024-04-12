using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class HealthBar : MonoBehaviour
{
    public Planet planet;         // Reference to the planet script
    public Image healthBarImage;  // Reference to the health bar image

    void Update()
    {
        if (planet != null && healthBarImage != null)
        {
            // Calculate the health percentage
            float healthPercent = (float)planet.currentHealth / planet.maxHealth;

            // Update the health bar's fill amount
            healthBarImage.fillAmount = healthPercent;
        }
        else
        {
            Debug.LogWarning("Planet or healthBarImage references are not assigned!");
        }
    }
}
