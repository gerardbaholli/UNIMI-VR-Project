using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardSystem : MonoBehaviour
{

    [SerializeField] int scoreRecord = 0;
    [SerializeField] string kill20 = "no";
    [SerializeField] string kill100 = "no";
    [SerializeField] string kill200 = "no";
    [SerializeField] string kill500 = "no";
    [SerializeField] string kill1000 = "no";

    [SerializeField] bool onStartResetAllData = false;

    private void Awake()
    {
        DeleteAllData(onStartResetAllData);
        LoadGame();
    }

    private void SaveGame()
    {
        PlayerPrefs.SetInt("ScoreRecord", scoreRecord);
        PlayerPrefs.SetString("Kill20", kill20);
        PlayerPrefs.SetString("Kill100", kill100);
        PlayerPrefs.SetString("Kill200", kill200);
        PlayerPrefs.SetString("Kill500", kill500);
        PlayerPrefs.SetString("Kill1000", kill1000);
        PlayerPrefs.Save();
        //Debug.Log("Game data saved!");
    }

    public void LoadGame()
    {
        scoreRecord = PlayerPrefs.GetInt("ScoreRecord");
        kill20 = PlayerPrefs.GetString("Kill20");
        kill100 = PlayerPrefs.GetString("Kill100");
        kill200 = PlayerPrefs.GetString("Kill200");
        kill500 = PlayerPrefs.GetString("Kill500");
        kill1000 = PlayerPrefs.GetString("Kill1000");
        //Debug.Log("ScoreRecord: " + scoreRecord);
        //Debug.Log("Kill100: " + kill100);
        //Debug.Log("Kill200: " + kill200);
        //Debug.Log("Kill500: " + kill500);
        //Debug.Log("Kill1000: " + kill1000);
        //Debug.Log("Game data loaded!");
    }

    public void SetKills(int kills)
    {
        if (kills >= 20)
            kill20 = "yes";
        else
            kill20 = "no";

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

    public int GetScoreRecord()
    {
        return scoreRecord;
    }

    public string GetKill20()
    {
        if (kill20 == "no")
            return "";
        else if (kill20 == "yes")
            return "completed";

        return kill20;
    }

    public string GetKill100()
    {
        if (kill100 == "no")
            return "";
        else if (kill100 == "yes")
            return "completed";

        return kill100;
    }

    public string GetKill200()
    {
        if (kill200 == "no")
            return "";
        else if (kill200 == "yes")
            return "completed";

        return kill200;
    }

    public string GetKill500()
    {
        if (kill500 == "no")
            return "";
        else if (kill500 == "yes")
            return "completed";

        return kill500;
    }

    public string GetKill1000()
    {
        if (kill1000 == "no")
            return "";
        else if (kill1000 == "yes")
            return "completed";

        return kill1000;
    }

}
