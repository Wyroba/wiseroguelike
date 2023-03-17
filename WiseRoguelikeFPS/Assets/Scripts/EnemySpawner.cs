using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // The prefab of the enemy object to spawn
    public GameObject enemy;

    // The offset in the upward direction for the spawned enemy
    public float spawnOffset = 1f;

    // The current spawned enemy object
    private GameObject spawnedEnemy;

    // Flag to check if the spawner is waiting for the delay to end
    private bool waitingForDelay = false;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn an enemy object when the script starts
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        // If the spawned enemy object has been destroyed and the spawner is not waiting for the delay to end, start the delay
        if (spawnedEnemy == null && !waitingForDelay)
        {
            waitingForDelay = true;
            Invoke("SpawnEnemy", 5f);
        }
    }

    // Spawn a new enemy object at the spawner's position
    private void SpawnEnemy()
    {
        // Calculate the position for the spawned enemy object
        Vector3 spawnPosition = transform.position + Vector3.up * spawnOffset;

        // Instantiate a new enemy object at the spawn position with no rotation
        spawnedEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);

        // Set the tag of the spawned enemy object to "SpawnedEnemy"
        spawnedEnemy.tag = "SpawnedEnemy";

        // Reset the waiting flag
        waitingForDelay = false;
    }
}
