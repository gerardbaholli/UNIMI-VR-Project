using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{

    [SerializeField] Canvas startUI;
    [SerializeField] Canvas gameUI;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI life;

    private GameStatus gameStatus;
    private Nexus nexus;
    private bool isNexusInstatiated = false;

    private void Start()
    {
        HideStartUI();
        HideGameUI();

        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void FixedUpdate()
    {
        UpdateUI();
    }

    public void ShowStartUI()
    {
        startUI.enabled = true;
    }

    public void HideStartUI()
    {
        startUI.enabled = false;
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
        if (isNexusInstatiated)
        {
            UpdateScore();
            UpdateLife();
        }
        else
        {
            UpdateScore();

            if (gameStatus.IsGameStarted())
            {
                isNexusInstatiated = true;
                nexus = FindObjectOfType<Nexus>();
            }
        }
    }

    private void UpdateLife()
    {
        life.text = ((int) nexus.GetCurrentLife()).ToString();
    }

    private void UpdateScore()
    {
        score.text = gameStatus.GetScore().ToString();
    }

}
