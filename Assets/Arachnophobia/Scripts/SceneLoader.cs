using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{

    int numberOfScenes;

    private void Start()
    {
        numberOfScenes = SceneManager.sceneCountInBuildSettings;
    }

    private IEnumerator WaitForSceneLoad(int sceneIndex, float delayOnSceneLoad)
    {
        yield return new WaitForSeconds(delayOnSceneLoad);
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadStartingScene(float delayOnSceneLoad)
    {
        StartCoroutine(WaitForSceneLoad(0, delayOnSceneLoad));
    }

    public void LoadNextScene(float delayOnSceneLoad)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;


        if (currentSceneIndex + 1 < numberOfScenes)
        {
            StartCoroutine(WaitForSceneLoad(currentSceneIndex + 1, delayOnSceneLoad));
        }
        else
        {
            LoadStartingScene(delayOnSceneLoad + 1f);
        }
    }

    public void ReloadScene(float delayOnSceneLoad)
    {
        StartCoroutine(WaitForSceneLoad(SceneManager.GetActiveScene().buildIndex, delayOnSceneLoad));
    }

}