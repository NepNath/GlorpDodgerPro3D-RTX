using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    
    [SerializeField] private GameObject deathScreen;

    public int HealthPoint;

    [SerializeField] private HeartDisplay heartDisplayScript;
    private void Awake()
    {
        deathScreen.SetActive(false);
        heartDisplayScript = FindFirstObjectByType<HeartDisplay>();
        if (heartDisplayScript != null)
        {
            heartDisplayScript.UpdateHeartsUI(HealthPoint);
        }
    }
    public void TakeDamage(int damage)
    {
        if (HealthPoint > 0)
        {
            HealthPoint -= damage;
            if (heartDisplayScript != null)
            {
                heartDisplayScript.UpdateHeartsUI(HealthPoint);
            }
        }
        if (HealthPoint <= 0)
        {
            if (heartDisplayScript != null)
            {
                heartDisplayScript.UpdateHeartsUI(HealthPoint);
            }
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("glorp ded :(");
        Destroy(gameObject);
        StartCoroutine(ThrowbackToMainMenu(3));
    }

    IEnumerator ThrowbackToMainMenu(int seconds)
    {
        deathScreen.SetActive(true);
        yield return new WaitForSecondsRealtime(seconds);
        SceneManager.LoadScene(1);
    }

}
