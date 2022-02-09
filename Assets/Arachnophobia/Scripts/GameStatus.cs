using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{

    [SerializeField] UIManager uiManager;
    [SerializeField] TextMeshProUGUI scoreText;

    [Header("Player Stats")]
    [SerializeField] float dmgAmount;
    [SerializeField] float shootSpeed;
    [SerializeField] TextMeshProUGUI dmgAmountText;
    [SerializeField] TextMeshProUGUI shootSpeedText;

    private Nexus nexus;
    private bool isGameStarted;
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
        isGameStarted = false;
        score = 0;
        dmgAmount = 1f;
        shootSpeed = 1f;
        dmgAmountText.text = dmgAmount.ToString("F2");
        shootSpeedText.text = shootSpeed.ToString("F2");
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

    public void SetDmgBonus(float value)
    {
        dmgAmount = value;
    }

    public void AddDmgBonus(float value)
    {
        dmgAmount += value;
    }

    public float GetDmgBonus()
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
