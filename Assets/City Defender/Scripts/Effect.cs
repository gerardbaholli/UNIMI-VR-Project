using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : Power
{

    [SerializeField] GameObject destroyEffect;

    public GameObject GetDestroyEffect()
    {
        return destroyEffect;
    }

}
