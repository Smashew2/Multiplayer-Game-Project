using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 5f;            // Speed of the projectile
    public int damage = 1;              // Damage inflicted by the projectile
    public string planetTag = "Planet"; // Tag of the planet GameObject
    public string shieldShipTag = "ShieldShip"; // Tag of the shield ship GameObject

    void Update()
    {
        // Move the projectile forward
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        // Check if the projectile collides with the planet
        if (other.CompareTag(planetTag))
        {
            // If the projectile collides with the planet, deal damage to it
            other.GetComponent<Planet>().TakeDamage(damage);

            // Destroy the projectile
            Destroy(gameObject);
        }
        // Check if the projectile collides with the shield ship
        else if (other.CompareTag(shieldShipTag))
        {
            // If the projectile collides with the shield ship, destroy it
            Destroy(gameObject);
        }
    }
}
