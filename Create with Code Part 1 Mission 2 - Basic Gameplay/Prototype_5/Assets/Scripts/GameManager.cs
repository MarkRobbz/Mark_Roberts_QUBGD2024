using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    private int score;
    public bool isGameActive;
    public Button restartBttn;
    public GameObject titlescreen;
    
    

    public void StartGame(int difficulty)
    {
        spawnRate = spawnRate / difficulty;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        updateScore(0);
        titlescreen.gameObject.SetActive(false);
    }


    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
           
        }
        
    }

    public void updateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.GameObject().SetActive(true);
        restartBttn.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverText.GameObject().SetActive(false);
        restartBttn.gameObject.SetActive(false);
    }
}
