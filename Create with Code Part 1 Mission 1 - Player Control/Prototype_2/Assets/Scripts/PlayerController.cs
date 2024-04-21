using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float rangeOfX = 10f;
    public float rangeOfZ = 5f;
    private int score = 0;
    private int lives = 3;

    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        
        if (transform.position.x < -rangeOfX)
        {
            transform.position = new Vector3(-rangeOfX, transform.position.y, transform.position.z);
        }else if (transform.position.x > rangeOfX)
        {
            transform.position = new Vector3(rangeOfX, transform.position.y, transform.position.z);
        } else if (transform.position.z < -rangeOfZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -rangeOfZ);
        } else if (transform.position.z > rangeOfZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, rangeOfZ);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            DecreaseLives();
        }
      
        
    }

    public int GetScore()
    {
        return score;
    }

   public void IncreaseScore()
    {
        score++;
    }

    public void DecreaseLives()
    {
        lives--;
        Debug.Log("Lives: " + lives);
        
        if (lives <= 0)
        {
            Debug.Log("Game Over");
        }
        
        
    }
}
