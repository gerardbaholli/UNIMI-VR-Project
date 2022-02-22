using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShowPopupReward : MonoBehaviour
{
    [SerializeField] Sprite reward;
    [SerializeField] Image[] rewardImage;
    private GameStatus gameStatus;
    private RewardSystem rewardSystem;

    private void LateUpdate()
    {
        if (gameStatus.GetKillCount() == 100)
        {
            // add rewardImage[0] to rewardUI
        }
    }

}
