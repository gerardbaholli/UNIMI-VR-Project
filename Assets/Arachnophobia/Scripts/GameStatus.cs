using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{

    [SerializeField] UIManager uiManager;
    [SerializeField] TextMeshProUGUI scoreText;

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

    /*
    private IEnumerator SpawnEnemies()
    {
        Instantiate(enemy, spawnPoints[0].transform.position,
            Quaternion.LookRotation(nexus.transform.position - spawnPoints[0].transform.position));

        Instantiate(enemy, spawnPoints[1].transform.position,
            Quaternion.LookRotation(nexus.transform.position - spawnPoints[1].transform.position));

        Instantiate(enemy, spawnPoints[2].transform.position,
            Quaternion.LookRotation(nexus.transform.position - spawnPoints[2].transform.position));

        Instantiate(enemy, spawnPoints[3].transform.position,
            Quaternion.LookRotation(nexus.transform.position - spawnPoints[3].transform.position));

        yield return new WaitForSeconds(spawnCooldown);

        StartCoroutine(SpawnEnemies());
    }
    */
}
