using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string b_name;
    public int b_score;
    public string m_name;

    private void Awake()
    {

        // keep only one instance, delete redundant
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int b_score;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData
        {
            name = b_name,
            b_score = b_score
        };

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            b_name = data.name;
            b_score = data.b_score;
        }
    }
}
