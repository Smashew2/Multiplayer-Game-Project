using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject missilePrefab;   // Reference to the missile prefab
    public Transform firePoint;        // Point from which the missile is fired
    public float fireInterval = 0.5f;  // Interval between consecutive shots in seconds

    void Start()
    {
        // Start firing coroutine
        StartCoroutine(FireMissiles());
    }

    System.Collections.IEnumerator FireMissiles()
    {
        while (true)
        {
            // Instantiate a missile at the fire point with no rotation
            Instantiate(missilePrefab, firePoint.position, Quaternion.identity);

            // Wait for the specified interval before firing the next missile
            yield return new WaitForSeconds(fireInterval);
        }
    }
}
