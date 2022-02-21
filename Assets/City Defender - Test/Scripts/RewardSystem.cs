using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSystem : MonoBehaviour
{

	[SerializeField] int scoreRecord = 5;
	[SerializeField] string kill100 = "yes";
	[SerializeField] string kill200 = "no";
	[SerializeField] string kill500 = "no";
	[SerializeField] string kill1000 = "no";

    private void Start()
    {
		SetKills(1002);
		SaveGame();
		LoadGame();
    }

    public void SaveGame()
	{
		PlayerPrefs.SetInt("ScoreRecord", scoreRecord);
		PlayerPrefs.SetString("Kill100", kill100);
		PlayerPrefs.SetString("Kill200", kill200);
		PlayerPrefs.SetString("Kill500", kill500);
		PlayerPrefs.SetString("Kill1000", kill1000);
		PlayerPrefs.Save();
		Debug.Log("Game data saved!");
	}

	public void LoadGame()
	{
		if (PlayerPrefs.HasKey("SavedInteger"))
		{
			var tempScoreRecord = PlayerPrefs.GetInt("ScoreRecord");
			var tempKill100 = PlayerPrefs.GetString("Kill100");
			var tempKill200 = PlayerPrefs.GetString("Kill200");
			var tempKill500 = PlayerPrefs.GetString("Kill500");
			var tempKill1000 = PlayerPrefs.GetString("Kill1000");
			Debug.Log("Game data loaded!");
			Debug.Log("ScoreRecord: " + tempScoreRecord);
			Debug.Log("Kill100: " + tempKill100);
			Debug.Log("Kill200: " + tempKill200);
			Debug.Log("Kill500: " + tempKill500);
			Debug.Log("Kill1000: " + tempKill1000);
		}
		else
			Debug.LogError("There is no save data!");
	}

	public void SetKills(int value)
    {
		switch (value)
		{
			case >= 1000:
				kill1000 = "yes";
				break;
			case >= 500:
				kill500 = "yes";
				break;
			case >= 200:
				kill200 = "yes";
				break;
			case >= 100:
				kill100 = "yes";
				break;
			default:
				break;
		}

		SaveGame();
	}

}
