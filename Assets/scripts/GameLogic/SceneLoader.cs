using UnityEditor;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    // 0 = menu principal
    // 1 = jeu
    // 2 = upgrade

    public static void LoadMainMenuScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public static void LoadGameScene()
    {
        GameSettings.roundEnded = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public static void LoadUpgradeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
