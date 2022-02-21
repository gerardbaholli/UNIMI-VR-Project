using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float delayOnSceneLoad = 0.3f;

    private GameStatus gameStatus;
    private int numberOfScenes;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        numberOfScenes = SceneManager.sceneCountInBuildSettings;
    }

    private IEnumerator WaitForSceneLoad(int sceneIndex, float delayOnSceneLoad)
    {
        yield return new WaitForSeconds(delayOnSceneLoad);
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadStartingScene(float delayOnSceneLoad)
    {
        if (gameStatus != null)
            Destroy(gameStatus);

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
        if (gameStatus != null)
            Destroy(gameStatus);

        StartCoroutine(WaitForSceneLoad(SceneManager.GetActiveScene().buildIndex, delayOnSceneLoad));
    }

    public void LoadSceneIndex(int sceneIndex)
    {
        if (gameStatus != null)
            Destroy(gameStatus);

        StartCoroutine(WaitForSceneLoad(sceneIndex, delayOnSceneLoad));
    }


}