using System.Collections.Generic;
using UnityEngine;

public class HeartDisplay : MonoBehaviour
{

    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private Transform heartContainer;
    private List<GameObject> hearts = new List<GameObject>();

    public void UpdateHeartsUI(int currentHealth)
    {
        while (hearts.Count < currentHealth)
        {
            GameObject newHeart = Instantiate(heartPrefab, heartContainer);
            hearts.Add(newHeart);
        }

        while (hearts.Count > currentHealth)
        {
            GameObject lastHeart = hearts[hearts.Count - 1];
            hearts.RemoveAt(hearts.Count - 1);
            Destroy(lastHeart);
        }
    }
}
