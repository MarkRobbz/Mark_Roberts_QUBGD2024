using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public float spawnRangeX = 20.0f;
    public float spawnPosZ = 20.0f;
    private float startDelay = 2.0f;
    private float spawnInterveal = 1.5f;
    private float spawnRangeZ = 10.0f;
    private float spawnPosX = 25.0f;
   
    

    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal",startDelay,spawnInterveal);
        InvokeRepeating("SpawnRightAnimal",startDelay,spawnInterveal);
        InvokeRepeating("SpawnLeftAnimal",startDelay,spawnInterveal);
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnRightAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(spawnPosX, 0, Random.Range(-spawnRangeZ, spawnRangeZ));
        Vector3 prefabRotation = new Vector3(0, -90, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(prefabRotation));
    }
    void SpawnLeftAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(-spawnPosX, 0, Random.Range(-spawnRangeZ, spawnRangeZ));
        Vector3 prefabRotation = new Vector3(0, 90, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(prefabRotation));
    }
}
