
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class ButtonInteraction : MonoBehaviour
{

    #if UNITY_EDITOR
    [SerializeField] private SceneAsset mainGameScene;

    private void OnValidate()
    {
        if (mainGameScene != null)
            mainGameSceneName = mainGameScene.name;
    }
    #endif

    [SerializeField] private string mainGameSceneName;
    public void loadGame()
    {
        SceneManager.LoadScene(mainGameSceneName);
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
