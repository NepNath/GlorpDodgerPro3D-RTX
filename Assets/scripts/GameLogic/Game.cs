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

    private float timerUntilWin;
    private float timer;
    private float projectileSpawnTimer;
    private float projectileSpawnInterval;



    [Header("Win/Death canvas")]
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject winScreen;

    [Header("Scenes")]
    [SerializeField] private SceneAsset mainMenuScene;
    public ProjectileSpawn ProjectileSpawn;

    private void Awake()
    {
        isGlorpAlive = true;
        deathScreen.SetActive(false);
        winScreen.SetActive(false);
        difficultySetter();
        Debug.Log("Difficulty Index : " + GameSettings.difficultyIndex);
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= timerUntilWin)

        {
            winScreen.SetActive(true);
            StartCoroutine(ThrowbackToMainMenu(3));
            Time.timeScale = 0f;
        }

        if (!isGlorpAlive)
        {
            deathScreen.SetActive(true);
            StartCoroutine(ThrowbackToMainMenu(3));
        }


        projectileSpawnTimer += Time.deltaTime;
        if (projectileSpawnTimer >= projectileSpawnInterval)
        {
            ProjectileSpawn.SpawnProjectile();
            projectileSpawnTimer = 0f;
        }
    }

    IEnumerator ThrowbackToMainMenu(int seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        SceneManager.LoadScene(mainMenuScene.name);
    }

    //private void StartGame()
    //{

    //}

    private void difficultySetter()
    {
        switch (GameSettings.difficultyIndex)
        {
            case 1:
                timerUntilWin = 10f;
                projectileSpawnInterval = 2f;
                break;
            case 2:
                timerUntilWin = 120f;
                projectileSpawnInterval = 1f;

                break; 
            case 3:
                timerUntilWin = 180f;
                projectileSpawnInterval = .5f;

                break;
        }
    }
}
