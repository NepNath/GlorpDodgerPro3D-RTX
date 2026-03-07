using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [Header("Game stats")]
    public int score;
    public int timeSurvived;
    public bool isGlorpAlive;
    public int difficultyIndex;
    private int roundAward;
    private bool roundEnded = false;

    [HideInInspector] public float timerUntilWin;
    [HideInInspector] public float timer;
    private float projectileSpawnTimer;
    private float projectileSpawnInterval;

    [Header("Win/Death canvas")]
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject winScreen;

    public ProjectileSpawn ProjectileSpawn;

    private void Awake()
    {
        if (deathScreen)
        {
            deathScreen.SetActive(false);
        }
        if (winScreen)
        {
            winScreen.SetActive(false);
        }

        Time.timeScale = 1f;
        isGlorpAlive = true;
        difficultySetter();
        Debug.Log("Difficulty Index : " + GameSettings.difficultyIndex);
        if (GameSettings.difficultyIndex == 0)
        {
            GameSettings.difficultyIndex = 1;
            Debug.Log("Difficulty Index not set, selecting easiest difficulty : " + GameSettings.difficultyIndex);

        }
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= timerUntilWin && !GameSettings.roundEnded)
        {
            GameSettings.roundEnded = true;

            if (winScreen) 
            {
                winScreen.SetActive(true);
                GameSettings.roundsSurvived += 1;
            }
            GameSettings.playerScore += roundAward;
            StartCoroutine(sendToUpgradeScene(3));
            Time.timeScale = 0f;
        }

        if (!isGlorpAlive)
        {
            if (deathScreen)
            {
                deathScreen.SetActive(true);
            }
            StartCoroutine(ThrowbackToMainMenu(3));
        }


        projectileSpawnTimer += Time.deltaTime;
        if (projectileSpawnTimer >= projectileSpawnInterval && ProjectileSpawn)
        {
            ProjectileSpawn.SpawnProjectile();
            projectileSpawnTimer = 0f;
        }
    }

    IEnumerator ThrowbackToMainMenu(int seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        SceneLoader.LoadMainMenuScene();
    }
    IEnumerator sendToUpgradeScene(int seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        SceneLoader.LoadUpgradeScene();
    }

    private void difficultySetter()
    {
        switch (GameSettings.difficultyIndex)
        {
            case -1:
                timerUntilWin = 5f;
                projectileSpawnInterval = 10000f;
                roundAward = 500;
                break;
            case 1:
                timerUntilWin = 60f;
                projectileSpawnInterval = 2f;
                roundAward = 100;
                break;
            case 2:
                timerUntilWin = 120f;
                projectileSpawnInterval = 1f;
                roundAward = 250;

                break;
            case 3:
                timerUntilWin = 180f;
                projectileSpawnInterval = .5f;
                roundAward = 500;

                break;
        }
    }
}
