using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDrop : MonoBehaviour
{

    [SerializeField] DropRate[] loots;
    [SerializeField] float secondsAfterDestroyDrop;

    private float noDropRate;

    private void Start()
    {
        CheckDropRateSum();
    }

    private void CheckDropRateSum()
    {
        float sum = 0;

        foreach (DropRate loot in loots) {
            sum += loot.GetRate();
        }

        if (sum > 1)
        {
            Debug.LogError("Drop Rate Error: sum > 1.");
        }

        noDropRate = 1 - sum;
    }

    public GameObject GenerateRandomDrop()
    {
        float sum = 0;

        float randomNumber = Random.Range(0f, 1f);

        foreach (DropRate loot in loots)
        {
            sum += loot.GetRate();

            if (randomNumber <= sum)
            {
                return loot.GetReward();
            }
        }

        Debug.Log("No reward drop.");
        return null;
    }

    public float GetSecondsAfterDestroyDrop()
    {
        return secondsAfterDestroyDrop;
    }

}
