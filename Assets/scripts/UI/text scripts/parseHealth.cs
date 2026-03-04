using UnityEngine;
using TMPro;
using TMPro.Examples;

public class parseHealth : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiText;

    private void Awake()
    {
        uiText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (uiText)
        {
            uiText.text = "Current hearths amount : " + GameSettings.playerHealth.ToString();
        } else
        {
            Debug.LogError(" Error : no health text found");
        }
    }
}
