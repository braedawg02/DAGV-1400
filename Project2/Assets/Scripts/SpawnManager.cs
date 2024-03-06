using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs; // Array of animal prefabs to spawn
    private float spawnRangeX = 20; // Range in which animals can be spawned on the X-axis
    private float spawnPosZ = 20; // Position on the Z-axis where animals will be spawned
    private float startDelay = 2; // Delay before the first animal is spawned
    private float spawnInterval = 1.5f; // Interval between spawning animals

    // Start is called before the first frame update
    void Start()
    {
        // Invoke the "spawnRandomAnimal" method repeatedly after the start delay, with the specified spawn interval
        InvokeRepeating("spawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        // No code in the Update method for now
    }

    // Method to spawn a random animal
    void spawnRandomAnimal()
    {
        // Generate a random index to select a random animal prefab from the array
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        // Generate a random spawn position within the specified range on the X-axis and at the specified position on the Z-axis
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        // Instantiate the selected animal prefab at the spawn position with its original rotation
        Instantiate(animalPrefabs[animalIndex], new Vector3(0, 0, 20), animalPrefabs[animalIndex].transform.rotation);
    }
}
