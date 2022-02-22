using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShowPopupReward : MonoBehaviour
{
    [SerializeField] Transform rewardPosition;
    [SerializeField] Sprite kill20;
    private GameStatus gameStatus;
    private RewardSystem rewardSystem;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        rewardSystem = FindObjectOfType<RewardSystem>();
    }

    private void LateUpdate()
    {
        if (gameStatus.GetKillCount() == 20)
        {
            rewardSystem.SetKills(gameStatus.GetKillCount());
            rewardSystem.SaveGame();
            StartCoroutine(LoadSpriteReward(kill20, 3f));
        }
    }

    private IEnumerator LoadSpriteReward(Sprite rewardSprite, float delay)
    {
        var temp = Instantiate(rewardSprite, rewardPosition.position, Quaternion.identity);
        yield return new WaitForSeconds(delay);
        Destroy(temp);
    }


}
