using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RewardUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreTMP;
    [SerializeField] TextMeshProUGUI kill100TMP;
    [SerializeField] TextMeshProUGUI kill200TMP;
    [SerializeField] TextMeshProUGUI kill500TMP;
    [SerializeField] TextMeshProUGUI kill1000TMP;

    private RewardSystem rewardSystem;

    private void Start()
    {
        rewardSystem = FindObjectOfType<RewardSystem>();
        scoreTMP.text = rewardSystem.GetScoreRecord().ToString();
        kill100TMP.text = rewardSystem.GetKill100();
        kill200TMP.text = rewardSystem.GetKill200();
        kill500TMP.text = rewardSystem.GetKill500();
        kill1000TMP.text = rewardSystem.GetKill1000();
    }


}
