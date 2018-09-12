using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject fallingBlockPrefab;
    public GameObject starPrefab;
    public float startingSpawnRate = 1f;
    public float spawnRateModifier = 0.01f;
    public float finalSpawnRate = 0.4f;
    float starSpawnRate = 0.1f;
    float nextStarSpawn;
    float currentSpawnRate;
    float nextSpawnTime;


    public Vector2 spawnSizeMinMax;
    public float spawnAngleMax;

    Vector2 screenHalfSizeWorldUnits;


    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        currentSpawnRate = startingSpawnRate;

    }

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + currentSpawnRate;
            if (currentSpawnRate > finalSpawnRate)
            {
                currentSpawnRate -= spawnRateModifier;
            }
            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            Vector3 spawnPosition = new Vector3(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), 0, 2 * screenHalfSizeWorldUnits.y + spawnSize);
            GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.up * spawnAngle));
            newBlock.transform.localScale = Vector3.one * spawnSize;
        }
        if (Time.time > nextStarSpawn)
        {
            nextStarSpawn = Time.time + starSpawnRate;
            Vector3 starPosition = new Vector3(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), -10, 2 * screenHalfSizeWorldUnits.y);
            Instantiate(starPrefab, starPosition, Quaternion.identity);
        }

    }
}
