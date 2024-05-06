using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
        
        Instantiate(enemyPrefab, generateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 generateSpawnPosition()
    {
        float spawnPostionX = Random.Range(-9, 9); //Code is a bit redundant but  allows for change of x or why in future
        float spawnPostionY = Random.Range(-9, 9);
        Vector3 randomPosition = new Vector3(spawnPostionX, spawnPostionY);

        return randomPosition;
    }
}
