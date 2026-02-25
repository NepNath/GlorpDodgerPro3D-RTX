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


    [HideInInspector] public float timerUntilWin;
    [HideInInspector] public float timer;
    private float projectileSpawnTimer;
    private float projectileSpawnInterval;



    [Header("Win/Death canvas")]
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject winScreen;

    
    private string mainMenuSceneName;
    private string upgradeSceneName;

    public ProjectileSpawn ProjectileSpawn;



    #if UNITY_EDITOR
    [Header("Scenes")]
    [SerializeField] private SceneAsset mainMenuScene;
    [SerializeField] private SceneAsset upgradeScene;

    private void OnValidate()
    {
        if (mainMenuScene != null)
            mainMenuSceneName = mainMenuScene.name;
        if (upgradeScene != null)
            upgradeSceneName = upgradeScene.name;
    }
    #endif


    private void Awake()
    {
        Time.timeScale = 1f;
        isGlorpAlive = true;
        deathScreen.SetActive(false);
        winScreen.SetActive(false);
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
        if (timer >= timerUntilWin)

        {
            winScreen.SetActive(true);
            StartCoroutine(sendToUpgradeScene(3));
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
        SceneManager.LoadScene(mainMenuSceneName);
    }
    IEnumerator sendToUpgradeScene(int seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        SceneManager.LoadScene(upgradeSceneName);
    }

    //private void StartGame()
    //{

    //}

    private void difficultySetter()
    {
        switch (GameSettings.difficultyIndex)
        {
            case 1:
                timerUntilWin = 60f;
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
