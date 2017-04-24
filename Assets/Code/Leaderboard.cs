using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public Text[] leaderboardScoresText, gameoverScoresText;
    public Text[] leaderboardDatesText, gameoverDatesText;
    public Text[] statsText;

    private List<KeyValuePair<int, string>> m_leaderboardScores;

    private void Start()
    {
        m_leaderboardScores = new List<KeyValuePair<int, string>>();
        LoadScores();
    }

    private void LoadScores()
    {
        m_leaderboardScores.Add(new KeyValuePair<int, string>(PlayerPrefs.HasKey("Score1") ? PlayerPrefs.GetInt("Score1") : 0,
            PlayerPrefs.HasKey("Date1") ? PlayerPrefs.GetString("Date1") : DateTime.Today.ToString("dd/MM/yyyy")));
        m_leaderboardScores.Add(new KeyValuePair<int, string>(PlayerPrefs.HasKey("Score2") ? PlayerPrefs.GetInt("Score2") : 0,
            PlayerPrefs.HasKey("Date2") ? PlayerPrefs.GetString("Date2") : DateTime.Today.ToString("dd/MM/yyyy")));
        m_leaderboardScores.Add(new KeyValuePair<int, string>(PlayerPrefs.HasKey("Score3") ? PlayerPrefs.GetInt("Score3") : 0,
            PlayerPrefs.HasKey("Date3") ? PlayerPrefs.GetString("Date3") : DateTime.Today.ToString("dd/MM/yyyy")));
        m_leaderboardScores.Add(new KeyValuePair<int, string>(PlayerPrefs.HasKey("Score4") ? PlayerPrefs.GetInt("Score4") : 0,
            PlayerPrefs.HasKey("Date4") ? PlayerPrefs.GetString("Date4") : DateTime.Today.ToString("dd/MM/yyyy")));
        m_leaderboardScores.Add(new KeyValuePair<int, string>(PlayerPrefs.HasKey("Score5") ? PlayerPrefs.GetInt("Score5") : 0,
            PlayerPrefs.HasKey("Date5") ? PlayerPrefs.GetString("Date5") : DateTime.Today.ToString("dd/MM/yyyy")));

        for (int i = 0; i < 5; i++)
        {
            if (leaderboardScoresText[i] != null)
            {
                leaderboardScoresText[i].text = m_leaderboardScores[i].Key.ToString();
                leaderboardDatesText[i].text = m_leaderboardScores[i].Value;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (gameoverScoresText[i] != null)
            {
                gameoverScoresText[i].text = m_leaderboardScores[i].Key.ToString();
                gameoverDatesText[i].text = m_leaderboardScores[i].Value;
            }
        }
    }

    public void AddScore(int score)
    {
        m_leaderboardScores.Add(new KeyValuePair<int, string>(score, DateTime.Today.ToString("dd/MM/yyyy")));
        m_leaderboardScores.Sort((s1, s2) => s2.Key.CompareTo(s1.Key));
        SaveScores();
    }

    public void AddPairings(int pairings)
    {
        if(statsText[0] != null)
        {
            statsText[0].text = pairings.ToString();
        }
    }

    public void AddMultiplier(int multi)
    {
        if(statsText[1] != null)
        {
            statsText[1].text = multi.ToString();
        }
    }

    public void SaveScores()
    {
        m_leaderboardScores.RemoveAt(5);

        PlayerPrefs.SetInt("Score1", m_leaderboardScores[0].Key);
        PlayerPrefs.SetInt("Score2", m_leaderboardScores[1].Key);
        PlayerPrefs.SetInt("Score3", m_leaderboardScores[2].Key);
        PlayerPrefs.SetInt("Score4", m_leaderboardScores[3].Key);
        PlayerPrefs.SetInt("Score5", m_leaderboardScores[4].Key);

        PlayerPrefs.SetString("Date1", m_leaderboardScores[0].Value);
        PlayerPrefs.SetString("Date2", m_leaderboardScores[1].Value);
        PlayerPrefs.SetString("Date3", m_leaderboardScores[2].Value);
        PlayerPrefs.SetString("Date4", m_leaderboardScores[3].Value);
        PlayerPrefs.SetString("Date5", m_leaderboardScores[4].Value);

        PlayerPrefs.Save();

        LoadScores();
    }

    public void ClearScores()
    {
        PlayerPrefs.DeleteAll();
        m_leaderboardScores = new List<KeyValuePair<int, string>>();
        LoadScores();
    }
}
