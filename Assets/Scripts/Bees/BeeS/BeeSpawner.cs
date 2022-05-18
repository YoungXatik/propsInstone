using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BeeSpawner : MonoBehaviour
{
    [SerializeField] public int beeCount;

    [SerializeField] private GameObject[] beeSpawnPoints;
    [SerializeField] private Transform[] beeSpawnPointsPosition;
    [SerializeField] private int spawnIndex;
    [SerializeField] private float timeBetweenSpawn;
    [SerializeField] public GameObject beePrefab;


    [SerializeField] private GameObject startButton;
    private void Start()
    {
        beeSpawnPoints = GameObject.FindGameObjectsWithTag("BeeSpawnPoint");
        
        for (int i = 0; i < beeSpawnPoints.Length; i++)
        {
            beeSpawnPointsPosition[i] = beeSpawnPoints[i].transform;
        }
    }

    public void ClickAndPlayCoroutine()
    {
        StartCoroutine("SpawnBee");
        Destroy(startButton);
    }

    IEnumerator SpawnBee()
    {
        Random random = new Random();
        spawnIndex = random.Next(1, 4);
        Debug.Log("BeeSpawnPos" + " " + spawnIndex);
        Instantiate(beePrefab, beeSpawnPointsPosition[spawnIndex]);
        beeCount++;
        yield return new WaitForSeconds(timeBetweenSpawn);
        StartCoroutine(SpawnBee());
    }
}
