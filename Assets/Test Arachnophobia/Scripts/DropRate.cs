using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DropRate
{
    [SerializeField] GameObject reward;
    [Range(0f, 1f)] [SerializeField] float dropRate;

    public float GetRate()
    {
        return dropRate;
    }

    public GameObject GetReward()
    {
        return reward;
    }
}
