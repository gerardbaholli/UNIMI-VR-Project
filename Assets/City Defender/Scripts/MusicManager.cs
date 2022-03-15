using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
	// true if using the game object name to start the music
	[SerializeField] bool useGONames = true;

	private AudioSource[] audioSources;
	private Dictionary<string, AudioSource> musicList;

	void Awake()
	{
		int numberOfMusicManager = FindObjectsOfType(GetType()).Length;
		if (numberOfMusicManager > 1)
		{
			gameObject.SetActive(false);
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}

		musicList = new Dictionary<string, AudioSource>();

		audioSources = gameObject.GetComponentsInChildren<AudioSource>();

		for (int i = 0; i < audioSources.Length; i++)
		{
			AudioSource s = audioSources[i];
			if (useGONames)
				musicList[s.gameObject.name] = s;
			else
				musicList[s.clip.name] = s;
		}
	}

	// custom method, dont use outside of this game
    private void Start()
    {
		if (SceneManager.GetActiveScene().name != "Game")
			PlayMusic("MenuMusic");
		else
			StopAll();
    }


    public void PlayMusic(string name, float pitchVariance = 0)
	{
		if (musicList.ContainsKey(name))
		{
			if (pitchVariance != 0) musicList[name].pitch = 1 + Random.Range(-pitchVariance, pitchVariance);

			if (!musicList[name].isPlaying)
				musicList[name].Play();

		}
		else Debug.LogWarning("No sound of name " + name + " exists");
	}

	public void MuteAll()
	{
		for (int i = 0; i < audioSources.Length; i++)
			audioSources[i].mute = true;
	}

	public void UnmuteAll()
	{
		for (int i = 0; i < audioSources.Length; i++)
			audioSources[i].mute = false;
	}

	public void StopAll()
	{
		for (int i = 0; i < audioSources.Length; i++)
			audioSources[i].Stop();
	}

	public bool isPlaying(string name)
	{
		if (musicList.ContainsKey(name))
		{
			return musicList[name].isPlaying;
		}
		else
		{
			Debug.LogWarning("No sound of name " + name + " exists");
			return false;
		}
	}

}