using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSystem : MonoBehaviour
{

    [SerializeField] int scoreRecord = 0;
    [SerializeField] string kill100 = "no";
    [SerializeField] string kill200 = "no";
    [SerializeField] string kill500 = "no";
    [SerializeField] string kill1000 = "no";

    [SerializeField] bool onStartResetAllData = false;

    private void Start()
    {
        DeleteAllData(onStartResetAllData);

        LoadGame();
        Debug.Log("Your record is " + scoreRecord);
    }

    private void SaveGame()
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
        scoreRecord = PlayerPrefs.GetInt("ScoreRecord");
        kill100 = PlayerPrefs.GetString("Kill100");
        kill200 = PlayerPrefs.GetString("Kill200");
        kill500 = PlayerPrefs.GetString("Kill500");
        kill1000 = PlayerPrefs.GetString("Kill1000");
        Debug.Log("ScoreRecord: " + scoreRecord);
        Debug.Log("Kill100: " + kill100);
        Debug.Log("Kill200: " + kill200);
        Debug.Log("Kill500: " + kill500);
        Debug.Log("Kill1000: " + kill1000);
        Debug.Log("Game data loaded!");
    }

    public void SetKills(int kills)
    {
        if (kills >= 100)
            kill100 = "yes";
        else
            kill100 = "no";

        if (kills >= 200)
            kill200 = "yes";
        else
            kill200 = "no";

        if (kills >= 500)
            kill500 = "yes";
        else
            kill500 = "no";

        if (kills >= 1000)
            kill1000 = "yes";
        else
            kill1000 = "no";

        SaveGame();
    }

    public void SetScore(int score)
    {
        if (score > scoreRecord)
            scoreRecord = score;

        SaveGame();
    }

    public void DeleteAllData(bool flag)
    {
        if (flag)
            PlayerPrefs.DeleteAll();
    }

}
