using UnityEngine;
 

public class GameSettings : MonoBehaviour
{
    public static int difficultyIndex;
    public static int playerMaxHealth;
    public static int playerHealth;
    public static int playerScore;
    public static int roundsSurvived;
    
    public static bool roundEnded;
    public static bool saveExist;


    public void initiateGame()
    {
        saveExist = false;
        difficultyIndex = 1;
        playerHealth = 3;
        playerScore = 0;
        roundsSurvived = 0;
    }
}
