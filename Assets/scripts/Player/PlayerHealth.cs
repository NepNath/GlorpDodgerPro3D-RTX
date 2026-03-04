using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private HeartDisplay heartDisplayScript;
    [SerializeField] private Game GameScript;

    private void Awake()
    {
        heartDisplayScript = FindFirstObjectByType<HeartDisplay>();
        if (heartDisplayScript != null)
        {
            heartDisplayScript.UpdateHeartsUI(GameSettings.playerHealth);
        }
    }
    public void TakeDamage(int damage)
    {
        if (GameSettings.playerHealth > 0)
        {
            GameSettings.playerHealth -= damage;
            if (heartDisplayScript != null)
            {
                heartDisplayScript.UpdateHeartsUI(GameSettings.playerHealth);
            }
        }
        if (GameSettings.playerHealth <= 0)
        {
            if (heartDisplayScript != null)
            {
                heartDisplayScript.UpdateHeartsUI(GameSettings.playerHealth);
            }
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("glorp ded :(");
        GameScript.isGlorpAlive = false;
        Destroy(gameObject);
    }

    public static void addHealth(int health)
    {
        if (GameSettings.playerScore >= 100)
        {
            GameSettings.playerScore -= 100;
            GameSettings.playerHealth += 1;
        }
    }

}
