using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) //This is a override function as its from MonoBehaviour
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
