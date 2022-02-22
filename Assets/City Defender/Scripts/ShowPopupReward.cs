using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class ShowPopupReward : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI rewardTMP;
    [SerializeField] float rewardDelay = 0.3f;

    private GameStatus gameStatus;
    private RewardSystem rewardSystem;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        rewardSystem = FindObjectOfType<RewardSystem>();
    }

    private void LateUpdate()
    {
        if (gameStatus.GetKillCount() >= 20 && rewardSystem.GetKill20() == "")
        {
            rewardSystem.SetKills(gameStatus.GetKillCount());
            rewardSystem.SaveGame();
            StartCoroutine(LoadSpriteReward("Kill 20\nenemies", rewardDelay));
        }
    }

    private IEnumerator LoadSpriteReward(string reward, float delay)
    {
        rewardTMP.text = reward;
        yield return new WaitForSeconds(delay);
        rewardTMP.text = "";
    }


}
