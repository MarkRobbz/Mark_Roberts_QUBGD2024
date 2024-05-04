using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRB;
    private GameObject _focalPoint;

    public float rollSpeed;
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
    }
}
