using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{

    [SerializeField] UIManager uiManager;

    private bool isGameStarted = false;
    private int score;
    private int time;

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

    public bool IsGameStarted()
    {
        return isGameStarted;
    }

    public void StartGame()
    {
        uiManager.HideStartUI();
        //uiManager.ShowGameUI();
        isGameStarted = true;
    }


}