using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePropellerSpin : MonoBehaviour
{

    public GameObject planePropeller;
    private Vector3 rotationSpeed = new Vector3(0, 0, 2);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        planePropeller.transform.Rotate(rotationSpeed);
    }
}
