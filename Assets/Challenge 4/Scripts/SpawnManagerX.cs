using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject powerUpPrefab;
    [SerializeField] GameObject player;

    int enemyCount;
    int waveNumber = 1;

    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyX>().Length;
        if (enemyCount == 0)
        {
            ResetPlayerPosition();
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        }
        
    }
    Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-10, 10);
        float spawnPosZ = Random.Range(20, 27);
        Vector3 randomSpawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomSpawnPos;
    }
    
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    void ResetPlayerPosition ()
    {
        player.transform.position = new Vector3(0, 1, -7);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

}
