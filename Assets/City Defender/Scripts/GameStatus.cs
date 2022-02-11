using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameStatus : MonoBehaviour
{
    [Header("UI Text")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI gameOverText;

    [Header("Player Stats")]
    [SerializeField] float dmgAmount;
    [SerializeField] float shootSpeed;
    [SerializeField] TextMeshProUGUI dmgAmountText;
    [SerializeField] TextMeshProUGUI shootSpeedText;

    private Nexus nexus;
    private bool isGameStarted;
    private int score;
    private UIManager uiManager;
    private SceneLoader sceneLoader;

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

        gameOverText.text = "";
    }

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        isGameStarted = false;
        score = 0;
        dmgAmount = 1f;
        shootSpeed = 1f;
        dmgAmountText.text = dmgAmount.ToString("F2");
        shootSpeedText.text = shootSpeed.ToString("F2");
    }

    private void FixedUpdate()
    {
        CheckGameOver();
    }

    private void CheckGameOver()
    {
        if (!IsGameOver())
            return;

        gameOverText.text = "GAME OVER\n" + "YOUR SCORE\n" + score.ToString();

        sceneLoader.LoadStartingScene(5f);
    }

    private bool IsGameOver()
    {
        return nexus.GetCurrentLife() <= 0;
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
        nexus = FindObjectOfType<Nexus>();
    }

    public int GetScore()
    {
        return score;
    }

    public void AddPointsToScore(int value)
    {
        score += value;
    }

    public void SetDmgAmount(float value)
    {
        dmgAmount = value;
    }

    public void AddDmgAmount(float value)
    {
        dmgAmount += value;
    }

    public float GetDmgAmount()
    {
        return dmgAmount;
    }

    public void SetShootSpeed(float value)
    {
        shootSpeed = value;
    }

    public void AddShootSpeed(float value)
    {
        shootSpeed += value;
    }

    public float GetShootSpeed()
    {
        return shootSpeed;
    }

}
