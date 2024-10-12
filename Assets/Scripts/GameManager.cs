using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName;
    public string bestPlayerName;
    public int bestScore = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadNameAndBestScore();
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public void SetBestScore(int score)
    {
        bestScore = score;
    }

    public int GetBestScore()
    {
        return bestScore;
    }

    public string GetBestPlayerName()
    {
        return bestPlayerName;
    }

    public void ResetBestScore()
    {
        bestScore = 0;
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int bestScore;
        public string bestPlayerName;
    }
    public void SaveNameAndBestScore()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.bestScore = bestScore;
        data.bestPlayerName = bestPlayerName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadNameAndBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            bestScore = data.bestScore;
            bestPlayerName = data.bestPlayerName;
        }
    }
}