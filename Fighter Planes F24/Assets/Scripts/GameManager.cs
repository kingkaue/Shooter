using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.Timeline.Actions;
using System.Diagnostics.Contracts;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    public GameObject cloud;
    public GameObject enemy2;
    public GameObject coin;
    public GameObject coinPickup;
    public GameObject health;
    public GameObject healthPickup;
    private int score;
    private int lives;

    private bool isPlayerAlive;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI restartText;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemy", 1f, 3f);
        InvokeRepeating("CreateEnemy2", 5f, 7f);
        InvokeRepeating("CreateCoin", 3f, Random.Range(3f, 8f));
        InvokeRepeating("CreateHealth", 3f, Random.Range(3f, 8f));
        CreateSky();
        score = 0;
        scoreText.text = "Score: " + score;
        lives = 3;
        livesText.text = "Lives: " + lives;
        isPlayerAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
      Restart();    
    }

    void CreateEnemy()
    {
        Instantiate(enemy, new Vector3(Random.Range(-7.5f, 7.5f), 6.3f, 0), Quaternion.identity);

    }
    void CreateEnemy2()
    {
        Instantiate(enemy2, new Vector3(Random.Range(-7.5f, 7.5f), 6.3f, 0), Quaternion.identity);

    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloud, transform.position, Quaternion.identity);
        }
    }

    public void EarnScore(int howMuch)
    {
        score = score + howMuch;
        scoreText.text = "Score: " + score;
    }

    void CreateCoin()
    {
        Instantiate(coin, new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(4f, -4f), 0), Quaternion.identity);
    }

    public void CoinPickup()
    {
        Instantiate(coinPickup, transform.position, Quaternion.identity);
    }

    public void UpdateLives(int howMuch)
    {
        livesText.text = "Lives: " + howMuch;
    }
    public void CreateHealth()
    {
        Instantiate(health, new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(4f, -4f), 0), Quaternion.identity);
    }

    public void HealthPickup()
    {
        Instantiate(healthPickup, transform.position, Quaternion.identity);
    }

    public void GameOver()
    {
        isPlayerAlive = false;
        CancelInvoke();
        gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
    }

    void Restart()
    {
        if(Input.GetKeyDown(KeyCode.R) && isPlayerAlive == false)
        {
            SceneManager.LoadScene("Game");
        }

    }

}
