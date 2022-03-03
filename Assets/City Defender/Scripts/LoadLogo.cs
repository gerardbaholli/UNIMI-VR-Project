using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLogo : MonoBehaviour
{

    [SerializeField] float logoDurationOnScreen = 3.5f;

    private void Start()
    {
        StartCoroutine(ChangeSceneAfterLogo());
    }

    private IEnumerator ChangeSceneAfterLogo()
    {
        yield return new WaitForSeconds(logoDurationOnScreen);
        SceneManager.LoadScene("Start");
    }

}
