using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRangeX = 8f;
    private float spawnPosY = 10;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    public bool startedSpawning = false;
    // Start is called before the first frame update
    void Update()
    {
        if (MainMenu.isGameActive == true && startedSpawning == false)
        {
            StartSpawn();
        }
    }

    // Update is called once per frame
    void SpawnRandomEnemy()
    {
        if(MainMenu.isGameActive == true)
        {
            // Generate random enemy index and random spawn position
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, 0);
            // instantiate enemy at random spawn location
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
        }
    }
    void StartSpawn()
    {   
        startedSpawning = true;
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);

    }
}
