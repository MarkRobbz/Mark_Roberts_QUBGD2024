using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRB;
    private GameObject _focalPoint;
    public int powerUpStrength = 4;
    public GameObject powerUpIndicator;

    public float rollSpeed;
    

    public bool hasPoowerUp = false;
    // Start is called before the first frame update
    void Start()
    {
        _playerRB = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float vertcialInput = Input.GetAxis("Vertical"); //forward input
        _playerRB.AddForce(_focalPoint.transform.forward * vertcialInput  * rollSpeed);
        powerUpIndicator.transform.position = _playerRB.position + new Vector3(0,-0.5f,0); //offset with vector 3
    }

    IEnumerator powerUpCountdownRotuine()
    {
        yield return new WaitForSeconds(6);
        hasPoowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Power Up"))
        {
            hasPoowerUp = true;
            powerUpIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(powerUpCountdownRotuine());

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPoowerUp)
        {
            Rigidbody enemyRB = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromEnemy = other.gameObject.transform.position - transform.position;
            enemyRB.AddForce(awayFromEnemy * powerUpStrength, ForceMode.Impulse);
            Debug.Log("Collided with: " + other.gameObject.name + " With power up set to " + hasPoowerUp);
        }
    }
}
