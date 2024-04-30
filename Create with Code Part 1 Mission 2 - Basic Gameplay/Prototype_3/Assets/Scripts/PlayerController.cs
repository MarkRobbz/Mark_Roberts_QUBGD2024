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

    public bool isGameOver = false;
    private AudioSource _audioSource;
    public ParticleSystem explosion;
    public ParticleSystem dirt;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    private Animator _playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifer;
        _playerAnimator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && !isGameOver) // !isGameOver is the same as isGameOver != true
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //Different types of force modes
            isOnGround = false;
            _playerAnimator.SetTrigger("Jump_trig");
            dirt.Stop();
            _audioSource.PlayOneShot(jumpSound,1.0f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        

        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirt.Play();
        } else if (other.gameObject.CompareTag("Obstacle"))
        {
            _playerAnimator.SetBool("Death_b", true);
            _playerAnimator.SetInteger("DeathType_int",1);
            isGameOver = true;
            Debug.Log("Game Over!");
            dirt.Stop();
            explosion.Play();
            _audioSource.PlayOneShot(crashSound,1.0f);
        }
    }
}
