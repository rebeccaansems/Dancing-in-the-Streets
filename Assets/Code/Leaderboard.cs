using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    private List<int> m_leaderboardScores;

    private void Start()
    {
        m_leaderboardScores = new List<int>();
        LoadScores();
    }

    private void LoadScores()
    {
        m_leaderboardScores.Add(PlayerPrefs.HasKey("Score1") ? PlayerPrefs.GetInt("Score1") : 0);
        m_leaderboardScores.Add(PlayerPrefs.HasKey("Score2") ? PlayerPrefs.GetInt("Score2") : 0);
        m_leaderboardScores.Add(PlayerPrefs.HasKey("Score3") ? PlayerPrefs.GetInt("Score3") : 0);
        m_leaderboardScores.Add(PlayerPrefs.HasKey("Score4") ? PlayerPrefs.GetInt("Score4") : 0);
        m_leaderboardScores.Add(PlayerPrefs.HasKey("Score5") ? PlayerPrefs.GetInt("Score5") : 0);

        Debug.Log(PlayerPrefs.GetInt("Score1") + " " + PlayerPrefs.GetInt("Score2") + " " + PlayerPrefs.GetInt("Score3") + " " + 
            PlayerPrefs.GetInt("Score4") + " " + PlayerPrefs.GetInt("Score5"));
    }

    public void AddScore(int score)
    {
        m_leaderboardScores.Add(score);
        m_leaderboardScores.Sort((s1, s2) => s2.CompareTo(s1));
        SaveScores();
    }

    public void SaveScores()
    {
        m_leaderboardScores.Remove(5);
        PlayerPrefs.SetInt("Score1", m_leaderboardScores[0]);
        PlayerPrefs.SetInt("Score2", m_leaderboardScores[1]);
        PlayerPrefs.SetInt("Score3", m_leaderboardScores[2]);
        PlayerPrefs.SetInt("Score4", m_leaderboardScores[3]);
        PlayerPrefs.SetInt("Score5", m_leaderboardScores[4]);
        PlayerPrefs.Save();
    }
}
