using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{

    private Button _difficultyBtn;
    private GameManager _gameManager;
    public int difficulty;


    private void Start()
    {
        _difficultyBtn = _difficultyBtn.GetComponent<Button>();
        _difficultyBtn.onClick.AddListener(SetDifficulty);

        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void SetDifficulty()
    {
        Debug.Log(gameObject.name + "Was clicked");
        
        _gameManager.StartGame(difficulty);
    }
}
