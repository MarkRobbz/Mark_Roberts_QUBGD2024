using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;

    public float jumpForce = 10;

    public float gravityModifer = 0;

    public bool isOnGround = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifer;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //Different types of force modes
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        isOnGround = true;
    }
}
