using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPathOnNexus : MonoBehaviour
{

    private void Start()
    {
        Nexus nexus = FindObjectOfType<Nexus>();
        transform.position = nexus.transform.position;
    }

}
