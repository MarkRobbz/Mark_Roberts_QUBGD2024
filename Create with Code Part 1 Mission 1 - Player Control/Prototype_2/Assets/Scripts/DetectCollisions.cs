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
            if (foodBar != null)
            {
                
                foodBar.Feed();
               
                Destroy(other.gameObject); //destroys projectile

                
                if (foodBar.GetCurrentFoodValue() >= foodBar.foodRequired)
                {
                    // If food requirement is met, increase score
                    player.GetComponent<PlayerController>().IncreaseScore();
                    Debug.Log("Score: " + player.GetComponent<PlayerController>().GetScore());
                    
                    StartCoroutine(DestroyAnimalWithDelay()); //destroy after short time
                }
            }
            else
            {
                Debug.LogError("FoodBar component not found on the Animal GameObject or its children.");
            }
        } 
    }

    IEnumerator DestroyAnimalWithDelay()
    {
        // wait 0.5 secs
        yield return new WaitForSeconds(0.5f);
        // Then destroy the animal
        Destroy(gameObject);
    }



}
