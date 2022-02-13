using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    [SerializeField] TestEnemy[] enemyList;
    [SerializeField] float startingSpawnCooldown;
    [SerializeField] [Range(0.001f, 0.2f)] float decreasingAmount = 1000f;
    [SerializeField] float minSpawnCooldown = 0.3f;

    private GameStatus gameStatus;
    private TestNexus nexus;
    private bool isCoroutineStarted = false;
    private int numberOfEnemy;
    public float spawnCooldown;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        nexus = FindObjectOfType<TestNexus>();
        numberOfEnemy = enemyList.Length;
        spawnCooldown = startingSpawnCooldown;
    }

    private void FixedUpdate()
    {
        //if (!gameStatus.IsGameStarted())
        //    return;

        if (isCoroutineStarted)
            return;

        isCoroutineStarted = true;
        //nexus = FindObjectOfType<TestNexus>();
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {

        int[] side = { -1, 1 };
        float xPos = Random.Range(6, 13) * side[Random.Range(0, 2)];
        float yPos = Random.Range(1, 10);
        float zPos = Random.Range(6, 13) * side[Random.Range(0, 2)];
        Vector3 spawnPosition = new(xPos, yPos, zPos);
        Debug.Log(spawnPosition);


        TestEnemy enemy = enemyList[Random.Range(0, numberOfEnemy - 1)];
        Debug.Log(enemy.name);

        Instantiate(enemy, gameObject.transform.position + spawnPosition,
        Quaternion.LookRotation(nexus.transform.position - spawnPosition));


        //DecreaseSpawnCooldown(gameStatus.GetScore() / decreasingAmount);
        DecreaseSpawnCooldown(decreasingAmount);
        Debug.Log("Cooldown: " + spawnCooldown);

        yield return new WaitForSeconds(spawnCooldown);
        StartCoroutine(SpawnEnemies());
    }

    public void SetSpawnCooldown(float value)
    {
        spawnCooldown = value;
    }

    public float GetSpawnCooldown()
    {
        return spawnCooldown;
    }

    private void DecreaseSpawnCooldown(float value)
    {
        if ((spawnCooldown - value) <= minSpawnCooldown)
        {
            spawnCooldown = minSpawnCooldown;
        }
        else
        {
            spawnCooldown -= value;
        }
    }

}
