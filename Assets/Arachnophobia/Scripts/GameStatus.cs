using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{

    [SerializeField] UIManager uiManager;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] SpawnPoint[] spawnPoint;
    [SerializeField] Enemy enemy;

    private bool isGameStarted = false;
    private int score;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;

        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();   
    }

    private void FixedUpdate()
    {
        UpdateScore();
    }

    public bool IsGameStarted()
    {
        return isGameStarted;
    }

    public void StartGame()
    {
        uiManager.HideStartUI();
        uiManager.ShowGameUI();
        isGameStarted = true;
        Instantiate(enemy, spawnPoint[0].transform.position, Quaternion.identity);
        Instantiate(enemy, spawnPoint[1].transform.position, Quaternion.identity);
        Instantiate(enemy, spawnPoint[2].transform.position, Quaternion.identity);
        Instantiate(enemy, spawnPoint[3].transform.position, Quaternion.identity);
    }

    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    public void AddPointsToScore(int value)
    {
        score += value;
    }

}