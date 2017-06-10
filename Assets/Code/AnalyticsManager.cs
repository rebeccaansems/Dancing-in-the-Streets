using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsManager : MonoBehaviour
{

    public static int numGamesSession = 0, numCheckLeaderboard = 0, numAdsWatched = 0, numFacebookShares;
    public static int totalNumGames, totalNumSessions, totalNumCheckLeaderboard, totalNumAdsWatched, totalNumFacebookShares;

    void Start()
    {
        if (PlayerPrefs.HasKey("TotalNumGames"))
        {
            totalNumAdsWatched = PlayerPrefs.GetInt("TotalNumAdsWatched");
            totalNumCheckLeaderboard = PlayerPrefs.GetInt("TotalNumCheckLeaderboard");
            totalNumFacebookShares = PlayerPrefs.GetInt("TotalNumFacebookShares");
            totalNumGames = PlayerPrefs.GetInt("TotalNumGames");
            totalNumSessions = PlayerPrefs.GetInt("TotalNumSessions");
        }
        else
        {
            totalNumAdsWatched = 0;
            totalNumCheckLeaderboard = 0;
            totalNumFacebookShares = 0;
            totalNumGames = 0;
            totalNumSessions = 1;
        }

        totalNumSessions++;
        SendGeneralEvent("StartedSession");
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("menuOn", 1);

        PlayerPrefs.SetInt("TotalNumAdsWatched", totalNumAdsWatched);
        PlayerPrefs.SetInt("TotalNumCheckLeaderboard", totalNumCheckLeaderboard);
        PlayerPrefs.SetInt("TotalNumFacebookShares", totalNumFacebookShares);
        PlayerPrefs.SetInt("TotalNumGames", totalNumGames);
        PlayerPrefs.SetInt("TotalNumSessions", totalNumSessions);

        SendGeneralEvent("QuitGame");
        SendGameplayEvent("QuitGame", -1);
    }

    void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            OnApplicationQuit();
        }
    }

    public static void StartedGame()
    {
        numGamesSession++;
        totalNumGames++;

        SendGeneralEvent("StartedGame");
        SendGameplayEvent("StartedGame", 0);
    }

    public static void FinishedGame(int score)
    {
        SendGeneralEvent("FinishedGame");
        SendGameplayEvent("FinishedGame", score);
    }

    public static void CheckedLeaderboard()
    {
        numCheckLeaderboard++;
        totalNumCheckLeaderboard++;
        SendGeneralEvent("CheckedLeaderboard");
    }

    public static void WatchedAd()
    {
        numAdsWatched++;
        totalNumAdsWatched++;
        SendGeneralEvent("WatchedAd");
    }

    public static void SharedToFacebook(bool success)
    {
        if (success)
        {
            numFacebookShares++;
            totalNumFacebookShares++;
            SendGeneralEvent("SharedFacebook");
        }
        else
        {
            SendGeneralEvent("SharedFacebook_Fail");
        }
    }

    static void SendGeneralEvent(string name)
    {
        Analytics.CustomEvent(name, new Dictionary<string, object> {
            { "Sessions_Total", totalNumSessions },
            { "Games_Total", totalNumGames },
            { "FacebookShares_Total", totalNumFacebookShares },
            { "CheckedLeaderboards_Total", totalNumCheckLeaderboard },
            { "AdsWatched_Total", totalNumAdsWatched },
            { "AdsWatched_Session", numAdsWatched },
            { "CheckedLeaderboards_Session", numCheckLeaderboard },
            { "FacebookShares_Session", numFacebookShares },
            { "Games_Session", numGamesSession },
            { "LocalTime", System.DateTime.Now }
        });
    }

    static void SendGameplayEvent(string name, int score)
    {
        Analytics.CustomEvent(name + "_GameStats", new Dictionary<string, object> {
            { "CurrentScore", score },
            { "Highscore1", PlayerPrefs.GetInt("Score1") },
            { "Highscore2", PlayerPrefs.GetInt("Score2")},
            { "Highscore3", PlayerPrefs.GetInt("Score3") },
            { "HighestPair", PlayerPrefs.GetInt("HighestPair")},
            { "HighestMulti", PlayerPrefs.GetInt("HighestMulti")},
            { "Sessions_Total", totalNumSessions },
            { "Games_Total", totalNumGames },
            { "Games_Session", numGamesSession },
            { "LocalTime", System.DateTime.Now }
        });
    }

}
