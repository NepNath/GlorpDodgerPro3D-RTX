using System.Collections;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    
    public int HealthPoint;

    [SerializeField] private HeartDisplay heartDisplayScript;
    [SerializeField] private Game GameScript;

 

    private void Awake()
    {

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
        GameScript.isGlorpAlive = false;
        Destroy(gameObject);
    }

}
