using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static int difficultyIndex;
    public static int playerMaxHealth;
    public static int playerHealth;
    public static int playerScore;
    public static bool roundEnded;

    public void initiateGame()
    {
        difficultyIndex = 1;
        playerHealth = 3;
        playerScore = 0;
    }
}
