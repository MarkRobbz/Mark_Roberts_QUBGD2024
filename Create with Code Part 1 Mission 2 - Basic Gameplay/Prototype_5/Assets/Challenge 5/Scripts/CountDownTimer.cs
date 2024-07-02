using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownTimer : MonoBehaviour
{
    private TextMeshProUGUI _timerText;
    private float _time = 60;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _timerText = GetComponent<TextMeshProUGUI>();
    

    }

    // Update is called once per frame
    void Update()
    {
       Timer();
    }

   

    public void Timer()
    {
        if (_time > 0)
        {
            _time -= Time.deltaTime;
            _timerText.text =  _time.ToString("#.00");
        }
        else if(_time <= 0)
        {
            _gameManager.GameOver();
        }
    }
}
