using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 2.0f;

    private Rigidbody _enemyRB;

    private GameObject _player;

    
    // Start is called before the first frame update
    void Start()
    {
        _enemyRB = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (_player.transform.position - transform.position).normalized;
        _enemyRB.AddForce( lookDirection * speed);

        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }
}
