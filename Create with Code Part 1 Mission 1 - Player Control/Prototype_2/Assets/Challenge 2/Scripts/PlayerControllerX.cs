using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float cooldown = 1f;
    private float time = 0f;
    
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && time > cooldown)
        {
            time = 0f;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }  
    }
}
