using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private Game game;

    private void Awake()
    {
        game = FindObjectOfType<Game>();
    }

    void Update()
    {
        int timeLeft = Mathf.CeilToInt(game.timerUntilWin - game.timer);
        timerText.text = "Time Left : " + timeLeft.ToString();
    }
}
