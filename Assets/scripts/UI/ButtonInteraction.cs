
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class ButtonInteraction : MonoBehaviour
{

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("game Quitted");
    }
    public void generateHealth()
    {
        PlayerHealth.addHealth(1);
    }

    public void setDifficulty(int index)
    {
        GameSettings.difficultyIndex = index;
    }
}
