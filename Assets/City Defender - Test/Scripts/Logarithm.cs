using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logarithm : MonoBehaviour
{
    [SerializeField] float startingSpawnCooldown = 5f;
    [SerializeField] [Range(0.001f, 0.2f)] float decreasingAmount = 0.05f;
    [SerializeField] float minSpawnCooldown = 0.3f;


    private bool isCoroutineStarted = false;
    public float spawnCooldown;
    public float count;

    private void Start()
    {
        count = 10f;
    }

    private void FixedUpdate()
    {
        //Debug.Log(Mathf.Log(Time.time, 0.5f) + 10.0f);

        if (isCoroutineStarted)
            return;

        isCoroutineStarted = true;
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {

        LogarithmicUpdateCooldown(0.5f, 10f);
        //DecreaseSpawnCooldown(decreasingAmount);
        Debug.Log("Cooldown: " + spawnCooldown);

        yield return new WaitForSeconds(spawnCooldown);
        StartCoroutine(SpawnEnemies());
    }

    private void LogarithmicUpdateCooldown(float _base, float other)
    {
        if (spawnCooldown < minSpawnCooldown)
            return;

        spawnCooldown = Mathf.Log(Time.time + 1, _base) + other;
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
