using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformPrefab;          // Prefab of the platform to be spawned
    public float platformSpawnInterval = 2f;   // Interval between platform spawns
    public float platformMinY = -1f;          // Minimum Y position for platform spawn
    public float platformMaxY = 2f;           // Maximum Y position for platform spawn
    public float platformMinX = -1f;          // Minimum X position for platform spawn
    public float platformMaxX = 2f;           // Maximum X position for platform spawn

    private float timer;                    // Timer for platform spawning
    private Vector2 lastPlatformPosition;   // Position of the last spawned platform

    void Start()
    {
        timer = platformSpawnInterval;                // Initialize the timer
        lastPlatformPosition = transform.position;    // Set the last platform position to the initial position of the PlatformManager
    }

    void Update()
    {
        timer -= Time.deltaTime;      // Decrease the timer by the elapsed time

        if (timer <= 0f)
        {
            SpawnPlatform();                    // Call the SpawnPlatform() function when the timer reaches zero
            timer = platformSpawnInterval;      // Reset the timer to the specified interval
        }
    }

    void SpawnPlatform()
    {
        // Calculate a random X position within the specified range
        float posX = Random.Range(platformMinX, platformMaxX);
        // Calculate a random Y position relative to the last spawned platform
        float posY = lastPlatformPosition.y + Random.Range(platformMinY, platformMaxY);

        // Instantiate a new platform using the prefab at the calculated position
        GameObject newPlatform = Instantiate(platformPrefab, new Vector2(posX, posY), Quaternion.identity);
        // Set the PlatformManager as the parent of the new platform
        newPlatform.transform.SetParent(transform);

        // Update the last platform position to the position of the newly spawned platform
        lastPlatformPosition = newPlatform.transform.position;

    }
}