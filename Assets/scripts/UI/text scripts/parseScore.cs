using UnityEngine;
using TMPro;
using TMPro.Examples;

public class parseScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiText;
    private Game game;

    private void Awake()
    {
        game = FindFirstObjectByType<Game>();
        uiText = GetComponent<TextMeshProUGUI>();

    }

    void Update()
    {
        if (uiText)
        {
            uiText.text = "Available points : " + game.score.ToString();
        } else
        {
            Debug.LogError(" Error : no text found");
        }
    }
}
