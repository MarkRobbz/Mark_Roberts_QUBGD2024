using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.UI;

public class FoodBar : MonoBehaviour
{
    public GameObject foodBar;
    public int foodRequired;

    private void Start()
    {
        foodBar.GetComponent<Slider>().maxValue = foodRequired;
    }

    public void Feed()
    {
        gameObject.GetComponent<Slider>().value += 1; //1 pizza slice
    }

    public int GetCurrentFoodValue()
    {
        return (int)gameObject.GetComponent<Slider>().value;
    }
}
