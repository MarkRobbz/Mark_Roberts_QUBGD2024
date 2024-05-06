using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    public int enemyCount;
    public int enemyWaveNumber = 1;

    public GameObject powerup;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyAI>().Length;

        if (enemyCount == 0)
        {
            
            SpawnEnemies(enemyWaveNumber);
            enemyWaveNumber++;
            SpawnPowerup();
        }
    }

    private Vector3 generateSpawnPosition()
    {
        float spawnPostionX = Random.Range(-8, 8); //Code is a bit redundant but  allows for change of x or why in future
        float spawnPostionZ = Random.Range(-8, 8);
        Vector3 randomPosition = new Vector3(spawnPostionX, 0, spawnPostionZ);

        return randomPosition;
    }
    private void SpawnEnemies(int enimiesToSpawn)
    {
        for (int i = 0; i < enimiesToSpawn; i++)
        {
            
            Instantiate(enemyPrefab, generateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private void SpawnPowerup()
    {
        Instantiate(powerup, generateSpawnPosition(), powerup.transform.rotation);
    }
}
