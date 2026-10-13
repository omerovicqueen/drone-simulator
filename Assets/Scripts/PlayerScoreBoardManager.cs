using System.Collections.Generic;

using UnityEngine;


public class PlayerScoreBoardManager : MonoBehaviour
{
    private const string saves = "ScoreBoard";
    public void SaveScoreBoard(string pname, float time)
    {
        ListScoreBoard currentList = LoadScores();
        PlayerScoreBoard newScore = new PlayerScoreBoard();
        newScore.name = pname;
        newScore.score = time;
        
        currentList.scores.Add(newScore);
        
        string jsonData = JsonUtility.ToJson(currentList);
        PlayerPrefs.SetString(saves, jsonData);
        PlayerPrefs.Save();
        
        
    }

    public string GetFormattedLeaderBoard()
    {
        ListScoreBoard savedData = LoadScores();
        if (savedData.scores.Count == 0)
        {
            return "henüz kayıt yok";
        }
        savedData.scores.Sort((oyuncu1, oyuncu2) => oyuncu1.score.CompareTo(oyuncu2.score));
        string finaltext = "LIDERLIK TABLOSU \n\n";
        for (int i = 0; i < savedData.scores.Count; i++)
        {
            finaltext += (i+1)+". "+savedData.scores[i].name+ " - " + savedData.scores[i].score.ToString("F1") + " sn\n";
        }
        return finaltext;
    }

    public ListScoreBoard LoadScores()
    {
        if (!PlayerPrefs.HasKey(saves))
        {
            return new ListScoreBoard();
        }
        else
        {
            string  jsonData = PlayerPrefs.GetString(saves);
            return  JsonUtility.FromJson<ListScoreBoard>(jsonData);
        }
    }
    
}
[System.Serializable]
public class PlayerScoreBoard
{
    public string name;
    public float score;
        
}
[System.Serializable]
public class ListScoreBoard
{
    public List<PlayerScoreBoard> scores = new List<PlayerScoreBoard>();

}
