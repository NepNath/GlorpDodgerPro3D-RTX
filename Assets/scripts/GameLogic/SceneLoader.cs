using UnityEditor;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{

    private static string mainMenuSceneName;
    private static string upgradeSceneName;
    private static string gameSceneName;

#if UNITY_EDITOR
    [Header("Scenes")]
    [SerializeField] private SceneAsset mainMenuScene;
    [SerializeField] private SceneAsset upgradeScene;
    [SerializeField] private SceneAsset gameScene;

    private void OnValidate()
    {
        if (mainMenuScene != null)
            mainMenuSceneName = mainMenuScene.name;
        if (upgradeScene != null)
            upgradeSceneName = upgradeScene.name;
        if (gameScene != null)
            gameSceneName = gameScene.name;
    }
#endif

    public static void LoadMainMenuScene()
    {
        if (!string.IsNullOrEmpty(mainMenuSceneName))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenuSceneName);
        }
        else
        {
            Debug.LogError("Main Menu scene name is not set.");
        }
    }
    public static void LoadUpgradeScene()
    {
        if (!string.IsNullOrEmpty(upgradeSceneName))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(upgradeSceneName);
        }
        else
        {
            Debug.LogError("Upgrade scene name is not set.");
        }
    }
    public static void LoadGameScene()
    {
        GameSettings.roundEnded = false;
        if (!string.IsNullOrEmpty(gameSceneName))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(gameSceneName);
        }
        else
        {
            Debug.LogError("Game scene name is not set.");
        }
    }

}
