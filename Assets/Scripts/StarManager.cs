using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StarManager : MonoBehaviour
{
    public GameObject starPrefab;  // Reference to the star prefab
    public Vector3 spawnArea = new Vector3(8, 0, 8);  // Define the area for spawning stars
    private bool isSpawning = false;  // To track if a spawn delay is active

    private void Start()
    {
        StartCoroutine(SpawnStarWithDelay());
    }

    private void Update()
    {
        // Check if no stars are present and not already waiting to spawn
        if (GameObject.FindGameObjectsWithTag("Star").Length == 0 && !isSpawning)
        {
            StartCoroutine(SpawnStarWithDelay());
        }
    }

    private IEnumerator SpawnStarWithDelay()
    {
        isSpawning = true;
        
        // Wait for 30-60 seconds before spawning a new star
        yield return new WaitForSeconds(Random.Range(30f, 60f));
        
        SpawnStar();
        isSpawning = false;
    }

    private void SpawnStar()
    {
        Vector3 randomPosition;
        
        // Keep generating positions until one does not violate the exclusion rule
        do
        {
            randomPosition = new Vector3(
                Random.Range(-spawnArea.x, spawnArea.x),
                1f,
                Random.Range(-spawnArea.z, spawnArea.z)
            );
        } while (randomPosition.x > -1f && randomPosition.x < 1f);
        
        // Instantiate the star prefab at the random position
        Instantiate(starPrefab, randomPosition, starPrefab.transform.rotation);
    }
}
