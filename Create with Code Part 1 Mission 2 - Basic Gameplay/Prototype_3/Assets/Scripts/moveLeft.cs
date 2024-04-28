using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed = 1;
    public float leftBound = -10;
    private PlayerController _playerControllerScript;
    
    void Start()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerControllerScript.isGameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x <= leftBound && gameObject.CompareTag("Obstacle")) 
        {
            Destroy(gameObject);
        }
        
    }
}
