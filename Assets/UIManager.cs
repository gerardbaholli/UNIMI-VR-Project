using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] Canvas startUI;
    //[SerializeField] Canvas gameUI;

    private void Start()
    {
        startUI.enabled = false;
        //gameUI.enabled = false;
    }

    public void ShowStartUI()
    {
        startUI.enabled = true;
    }

    public void HideStartUI()
    {
        startUI.enabled = false;
    }

    public void ShowGameUI()
    {
        //gameUI.enabled = true;
    }

    public void HideGameUI()
    {
        //gameUI.enabled = false;
    }

}
