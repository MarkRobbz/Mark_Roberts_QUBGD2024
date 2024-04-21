using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile") && gameObject.CompareTag("Animal"))
        {
            FoodBar foodBar = gameObject.GetComponentInChildren<FoodBar>();

            if (foodBar != null && foodBar.GetCurrentFoodValue() < foodBar.foodRequired)
            {
                foodBar.Feed();
                Destroy(other.gameObject); //Destroy projectile
            }
            else
            {
                player.GetComponent<PlayerController>().IncreaseScore();
                Debug.Log("Score: " + player.GetComponent<PlayerController>().GetScore());
                Destroy(gameObject); //Destroy animal
                Destroy(other.gameObject); //Destroy projectile
            }
        } 
    }

}
