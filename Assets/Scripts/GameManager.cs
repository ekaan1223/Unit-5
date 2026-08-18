using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
    

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    public Button restartButton;
    public GameObject titleScreen;
    private int score;
    public int lives;
    public bool isGameActive;
    public List<GameObject> targets;
    public float SpawnRate = 1.0f;
    
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive == true)
        {
            yield return new WaitForSeconds(SpawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

           
        }
        
    }


    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int livesToAdd)
    {
        lives += livesToAdd; //this means lives = lives + livesToAdd and this means that if livesToAdd is -1 then it will subtract 1 from lives
        livesText.text = "Lives: " + lives;
    }
    public void GameOver()
    {
        
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        
        isGameActive = false;
    }

    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

   public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        lives = 3;
        SpawnRate = SpawnRate / difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        titleScreen.SetActive(false);
    }
}





