using UnityEngine;
using System.IO;

public class SaveFunctions : MonoBehaviour
{

    public static string savePath => Application.persistentDataPath + "/save.json";

    public void saveGame()
    {
        SaveData data = new SaveData
        {
            playerHealth = GameSettings.playerHealth,
            roundsSurvived = GameSettings.roundsSurvived,
            playerScore = GameSettings.playerScore
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Game saved at : " + savePath);
        GameSettings.saveExist = true;
    }

    public void loadGame()
    {
        if (!File.Exists(savePath))
        {
            Debug.LogWarning("No save file found.");
            return;
        }

        string json = File.ReadAllText(savePath);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        GameSettings.playerHealth = data.playerHealth;
        GameSettings.roundsSurvived = data.roundsSurvived;
        GameSettings.playerScore = data.playerScore;

        Debug.Log("Game loaded from : " + savePath);
    }

    public void deleteSave()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
            Debug.Log("Save deleted.");
        }
        GameSettings.saveExist = false;

    }
}
