using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _horsepower;
    [SerializeField] private float speed;
    [SerializeField] private float rpm;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody _playerRB;
    [SerializeField] private GameObject _centerOfMass;
    [SerializeField] private TextMeshProUGUI speedometerTMP;
    [SerializeField] private TextMeshProUGUI rmpTMP;
    [SerializeField] private List<WheelCollider> _wheelColliders;
    [SerializeField] private int wheelsOnGround;

public string inputID;
    // Start is called before the first frame update
    void Start()
    {
        _playerRB = GetComponent<Rigidbody>();
        _playerRB.centerOfMass = _centerOfMass.transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Play Input
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        verticalInput = Input.GetAxis("Vertical" + inputID);

        if (WheelsOnGround())
        {
            // Move the vehicle forward
                    _playerRB.AddRelativeForce(Vector3.forward  * verticalInput * _horsepower);
                    //transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
                    //Turns the vechicle
                    transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
            
                    speed = Mathf.RoundToInt(_playerRB.velocity.magnitude * 2.237f); //Miles per hour
                    speedometerTMP.SetText("Speed: " + speed +" MPH");
            
                    rpm = Mathf.RoundToInt(speed % 30) * 40;
                    rmpTMP.SetText("RPM: " + rpm);
        }
        
    }

    bool WheelsOnGround()
    {
        wheelsOnGround = 0;

        foreach (WheelCollider wheel in _wheelColliders)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
