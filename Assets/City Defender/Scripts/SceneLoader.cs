using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float delayOnSceneLoad = 0.3f;
    [SerializeField] AudioClip clickSound;

    private GameStatus gameStatus;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
    }

    public void LoadStartingScene(float delayOnSceneLoad)
    {
        if (gameStatus != null)
            Destroy(gameStatus);

        StartCoroutine(WaitForSceneLoad(0, delayOnSceneLoad));
    }

    public void ReloadScene(float delayOnSceneLoad)
    {
        if (gameStatus != null)
            Destroy(gameStatus);

        StartCoroutine(WaitForSceneLoad(SceneManager.GetActiveScene().buildIndex, delayOnSceneLoad));
    }

    public void LoadGameScene(float delayOnSceneLoad)
    {
        Music music = FindObjectOfType<Music>();
        if (music != null)
            Destroy(music);

        StartCoroutine(WaitForSceneLoad(1, delayOnSceneLoad));
    }

    private IEnumerator WaitForSceneLoad(int sceneIndex, float delayOnSceneLoad)
    {
        AudioSource.PlayClipAtPoint(clickSound, Camera.main.transform.position);
        yield return new WaitForSeconds(delayOnSceneLoad);
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

}