using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGS : MonoBehaviour
{

    [SerializeField] int kills;
    [SerializeField] int score;

    RewardSystem rewardSystem;

    private void Start()
    {
        rewardSystem = FindObjectOfType<RewardSystem>();

        StartCoroutine(SetRewards());
    }

    IEnumerator SetRewards()
    {
        yield return new WaitForSeconds(3f);

        rewardSystem.SetKills(kills);
        rewardSystem.SetScore(score);
    }
}
