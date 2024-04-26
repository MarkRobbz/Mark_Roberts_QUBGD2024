using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacleObj;

    private Vector3 _spawnPos = new Vector3(25, 0, 0);
    private GameObject _obstacleObjInstantiated;

    private float _startDelay = 2;

    private float _repeatRate = 2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", _startDelay, _repeatRate);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (obstacleObj.transform.position.x <= -10) //Needs fixen
        {
            Destroy(_obstacleObjInstantiated);
        }
    }

    void SpawnObstacle()
    {
       _obstacleObjInstantiated = Instantiate(obstacleObj, _spawnPos, obstacleObj.transform.rotation);
        
    }
}
