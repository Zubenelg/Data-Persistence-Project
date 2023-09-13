using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int BestScore;
    public string BestPlayerName;
    public string PlayerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestPlayer();
    }

    [System.Serializable]
    class SaveData
    {
        public string Name;
        public int Score;
    }

    public void SaveBestPlayer()
    {
        SaveData saveData = new SaveData();
        saveData.Name = BestPlayerName;
        saveData.Score = BestScore;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            BestPlayerName = saveData.Name;
            BestScore = saveData.Score;
        }
    }
}
