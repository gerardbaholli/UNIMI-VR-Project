using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour
{
    [SerializeField] Canvas userInterface;

    private void Start()
    {
        userInterface.enabled = false;
    }

    private void FixedUpdate()
    {
        if (Input.anyKey)
        {
            userInterface.enabled = true;
            Debug.Log("ENABLED");
        }
    }


}
