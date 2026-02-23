using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonInteraction : MonoBehaviour
{
    [SerializeField] private SceneAsset mainGameScene;
    public void loadGame()
    {
        SceneManager.LoadScene(mainGameScene.name);
    }
    public void quitGame()
    {
        Application.Quit();
        Debug.Log("game Quitted");
    }

    public void setDifficulty(int index)
    {
        GameSettings.difficultyIndex = index;
    }
}
