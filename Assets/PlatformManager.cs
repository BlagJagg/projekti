using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public float platformSpawnInterval = 2f;
    public float platformMinY = -4f;
    public float platformMaxY = 4f;
    public float platformMinX = -4f;
    public float platformMaxX = 4f;

    private float timer;
    private Vector2 lastPlatformPosition;

    void Start()
    {
        timer = platformSpawnInterval;
        lastPlatformPosition = transform.position;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnPlatform();
            timer = platformSpawnInterval;
        }
    }

    void SpawnPlatform()
    {
        float posX = Random.Range(platformMinX, platformMaxX);
        float posY = lastPlatformPosition.y + Random.Range(platformMinY, platformMaxY);

        GameObject newPlatform = Instantiate(platformPrefab, new Vector2(posX, posY), Quaternion.identity);
        newPlatform.transform.SetParent(transform);

        lastPlatformPosition = newPlatform.transform.position;
    }
}
