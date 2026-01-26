using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int HealthPoint;

    public void TakeDamage(int damage)
    {
        if(HealthPoint > 0)
        {
            HealthPoint -= damage;
        }
        if(HealthPoint <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("glorp ded :(");
        Destroy(gameObject);
    }
}
