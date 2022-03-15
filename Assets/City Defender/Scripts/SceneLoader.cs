using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float delayOnSceneLoad = 0.5f;
    [SerializeField] AudioClip clickSound;

    private GameStatus gameStatus;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
    }

    public void LoadStartingScene(float delayOnSceneLoad)
    {
        if (gameStatus != null)
            Destroy(gameStatus.gameObject);

        StartCoroutine(WaitForMenuSceneLoad(1));
    }

    public void ReloadScene(float delayOnSceneLoad)
    {
        if (gameStatus != null)
            Destroy(gameStatus.gameObject);

        StartCoroutine(WaitForGameSceneLoad(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadGameScene(float delayOnSceneLoad)
    {
        StartCoroutine(WaitForGameSceneLoad(2));
    }

    private IEnumerator WaitForGameSceneLoad(int sceneIndex)
    {
        AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position);
        yield return new WaitForSeconds(delayOnSceneLoad);
        FindObjectOfType<MusicManager>().StopAll();
        SceneManager.LoadScene(sceneIndex);
    }

    private IEnumerator WaitForMenuSceneLoad(int sceneIndex)
    {
        AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position);
        yield return new WaitForSeconds(delayOnSceneLoad);
        FindObjectOfType<MusicManager>().PlayMusic("MenuMusic");
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneWithDelay(sceneName));
    }

    private IEnumerator LoadSceneWithDelay(string sceneName)
    {
        AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position);
        yield return new WaitForSeconds(delayOnSceneLoad);
        SceneManager.LoadScene(sceneName);
    }

    public void GameOver(float delay)
    {
        StartCoroutine(WaitGameOver(delay));
    }

    private IEnumerator WaitGameOver(float delay)
    {
        yield return new WaitForSeconds(delay);
        LoadStartingScene(0f);
    }

}