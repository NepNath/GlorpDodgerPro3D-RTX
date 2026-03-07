using UnityEngine;
using TMPro;

public class RoundSurvived : MonoBehaviour
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
            uiText.text = "Survived rounds : " + GameSettings.roundsSurvived.ToString();
        } else
        {
            Debug.LogError(" Error : no score text found");
        }
    }
}
