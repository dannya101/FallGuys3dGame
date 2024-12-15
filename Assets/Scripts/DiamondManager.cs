using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondManager : MonoBehaviour
{
    public GameObject diamondPrefab;  // Reference to the diamond prefab
    public int maxDiamonds = 2;       // Number of diamonds to maintain
    public Vector3 spawnArea = new Vector3(7, 0, 7);  // Define the area for spawning diamonds
    private bool isSpawning = false;  // To track if a spawn delay is active

    private void Start()
    {
        StartCoroutine(SpawnDiamondWithDelay());
    }

    private void Update()
    {
        // Check if no diamonds are present and not already waiting to spawn
        if (GameObject.FindGameObjectsWithTag("Diamond").Length < maxDiamonds && !isSpawning)
        {
            StartCoroutine(SpawnDiamondWithDelay());
        }
    }

    private IEnumerator SpawnDiamondWithDelay()
    {
        isSpawning = true;
        
        // Wait for 10-90 seconds before spawning a new diamond
        yield return new WaitForSeconds(Random.Range(10f, 90f));
        
        SpawnDiamond();
        isSpawning = false;
    }

    private void SpawnDiamond()
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
        
        // Instantiate the diamond prefab at the random position
        Instantiate(diamondPrefab, randomPosition, diamondPrefab.transform.rotation);
    }
}
