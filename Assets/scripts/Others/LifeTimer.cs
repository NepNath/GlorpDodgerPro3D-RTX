using UnityEngine;

public class LifeTimer : MonoBehaviour
{

    [SerializeField] private float maxAliveTime;
    private float timer;
    private void Update()
    {
        lifeTimer();
    }
    void lifeTimer()
    {
        timer += Time.deltaTime;
        if (timer >= maxAliveTime)
        {
            Destroy(gameObject);
        }
    }
}
