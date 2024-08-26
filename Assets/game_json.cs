using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public GameData gameData;

    void Start()
    {
        LoadGameData();
    }

    void LoadGameData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "gameData.json");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(json);
            Debug.Log("Game data loaded successfully.");
        }
        else
        {
            Debug.LogError("Cannot find gameData.json file.");
        }
    }
}
