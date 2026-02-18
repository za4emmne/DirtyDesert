/*
 * This script is responsible for managing the instantiation of objects in the game.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
    // Variables for controlling object spawning
    public GameObject objectToSpawn;
    public float spawnDelay = 1.0f;
    private float currentSpawnDelay;
    private List<GameObject> spawnedObjects = new List<GameObject>();

    // Method for setting spawn delays
    public void SetSpawnDelays(float delay)
    {
        spawnDelay = delay;
    }

    // Method for weighted spawning
    public void WeightedSpawn(int weight)
    {
        for (int i = 0; i < weight; i++)
        {
            GameObject obj = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            spawnedObjects.Add(obj);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentSpawnDelay = spawnDelay;
        // Example of how to use the weighted spawn
        WeightedSpawn(3); // Spawns the object 3 times
    }

    // Update is called once per frame
    void Update()
    {
        // Handle spawn timing here
        if (currentSpawnDelay <= 0)
        {
            WeightedSpawn(1); // Adjust the weight as needed
            currentSpawnDelay = spawnDelay;
        }
        else
        {
            currentSpawnDelay -= Time.deltaTime;
        }
    }
}