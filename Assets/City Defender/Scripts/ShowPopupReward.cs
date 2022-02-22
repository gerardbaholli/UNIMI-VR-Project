using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class ShowPopupReward : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI rewardTMP;
    [SerializeField] AudioClip rewardSound;
    [SerializeField] float rewardDelay = 5f;

    private GameStatus gameStatus;
    private RewardSystem rewardSystem;
    private AudioSource audioSource;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        rewardSystem = FindObjectOfType<RewardSystem>();
        audioSource = FindObjectOfType<AudioSource>();

        rewardTMP.text = "";
    }

    private void LateUpdate()
    {
        CheckKill20Reward();
        CheckKill100Reward();
        CheckKill200Reward();
        CheckKill500Reward();
        CheckKill1000Reward();
    }

    private void CheckKill20Reward()
    {
        if (gameStatus.GetKillCount() >= 20 && rewardSystem.GetKill20() == "")
        {
            rewardSystem.SetKills(gameStatus.GetKillCount());
            rewardSystem.SaveGame();
            StartCoroutine(LoadSpriteReward("Kill 20\nenemies", rewardDelay));
        }
    }
    private void CheckKill100Reward()
    {
        if (gameStatus.GetKillCount() >= 100 && rewardSystem.GetKill100() == "")
        {
            rewardSystem.SetKills(gameStatus.GetKillCount());
            rewardSystem.SaveGame();
            StartCoroutine(LoadSpriteReward("Kill 100\nenemies", rewardDelay));
        }
    }

    private void CheckKill200Reward()
    {
        if (gameStatus.GetKillCount() >= 200 && rewardSystem.GetKill200() == "")
        {
            rewardSystem.SetKills(gameStatus.GetKillCount());
            rewardSystem.SaveGame();
            StartCoroutine(LoadSpriteReward("Kill 200\nenemies", rewardDelay));
        }
    }

    private void CheckKill500Reward()
    {
        if (gameStatus.GetKillCount() >= 500 && rewardSystem.GetKill500() == "")
        {
            rewardSystem.SetKills(gameStatus.GetKillCount());
            rewardSystem.SaveGame();
            StartCoroutine(LoadSpriteReward("Kill 500\nenemies", rewardDelay));
        }
    }

    private void CheckKill1000Reward()
    {
        if (gameStatus.GetKillCount() >= 1000 && rewardSystem.GetKill1000() == "")
        {
            rewardSystem.SetKills(gameStatus.GetKillCount());
            rewardSystem.SaveGame();
            StartCoroutine(LoadSpriteReward("Kill 1000\nenemies", rewardDelay));
        }
    }

    private IEnumerator LoadSpriteReward(string reward, float delay)
    {
        rewardTMP.text = reward;
        audioSource.PlayOneShot(rewardSound);
        yield return new WaitForSeconds(delay);
        rewardTMP.text = "";
    }

}
