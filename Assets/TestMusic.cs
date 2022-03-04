using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMusic : MonoBehaviour
{


    void Start()
    {
        FindObjectOfType<MusicManager>().PlayMusic("MenuMusic");
    }

}
