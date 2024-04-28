using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacleObj;

    private Vector3 _spawnPos = new Vector3(25, 0, 0);
    private GameObject _obstacleObjInstantiated;
    private PlayerController _playerControllerScript;

    private float _startDelay = 2;

    private float _repeatRate = 2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", _startDelay, _repeatRate);
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (_playerControllerScript.isGameOver == false)
        {
            _obstacleObjInstantiated = Instantiate(obstacleObj, _spawnPos, obstacleObj.transform.rotation);
        }
       
        
    }
}
