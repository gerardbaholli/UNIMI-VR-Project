using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{

    [SerializeField] Canvas gameUI;
    [SerializeField] TextMeshProUGUI score;

    private GameStatus gameStatus;

    private void Start()
    {
        HideGameUI();

        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void FixedUpdate()
    {
        UpdateUI();
    }

    public void ShowGameUI()
    {
        gameUI.enabled = true;
    }

    public void HideGameUI()
    {
        gameUI.enabled = false;
    }

    private void UpdateUI()
    {
        if (!gameStatus.IsGameStarted())
            return;

        UpdateScore();
    }

    private void UpdateScore()
    {
        score.text = gameStatus.GetScore().ToString();
    }

}
