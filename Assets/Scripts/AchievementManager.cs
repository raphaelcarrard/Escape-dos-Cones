using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;

public class AchievementManager : MonoBehaviour
{
    
    public static AchievementManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void CheckAchievements()
    {
        if(PlayerScript.instance.pontuacao >= 5)
        {
            PlayGamesPlatform.Instance.ReportProgress(Achievements.achievement5Points, 100f, (bool success) => { });
        }
        if (PlayerScript.instance.pontuacao >= 10)
        {
            PlayGamesPlatform.Instance.ReportProgress(Achievements.achievement10Points, 100f, (bool success) => { });
        }
        if (PlayerScript.instance.pontuacao >= 30)
        {
            PlayGamesPlatform.Instance.ReportProgress(Achievements.achievement30Points, 100f, (bool success) => { });
        }
        if (PlayerScript.instance.pontuacao >= 50)
        {
            PlayGamesPlatform.Instance.ReportProgress(Achievements.achievement50Points, 100f, (bool success) => { });
        }
        if (PlayerScript.instance.pontuacao >= 100)
        {
            PlayGamesPlatform.Instance.ReportProgress(Achievements.achievement100Points, 100f, (bool success) => { });
        }
    }
}
