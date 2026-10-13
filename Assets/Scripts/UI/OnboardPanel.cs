using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OnboardPanel : MonoBehaviour
{
    public GameManager gameManager;
    public Button startButton;
    public Button exitButton;
    public PlayerScoreBoardManager playerScoreBoard; 
    public TMP_Text leaderboardText;
    public void OnEnable()
    {
        startButton.onClick.AddListener(OnStartButtonPerformed);
        exitButton.onClick.AddListener(OnExitButtonPerformed);
        if (playerScoreBoard != null && leaderboardText != null)
        {
            leaderboardText.text = playerScoreBoard.GetFormattedLeaderBoard();
        }
    }

    public void OnDisable()
    {
        startButton.onClick.RemoveListener(OnStartButtonPerformed);
        exitButton.onClick.RemoveListener(OnExitButtonPerformed);
    }

    private void OnStartButtonPerformed()
    {
        gameManager.ChangeGameState(GameStateType.Gameplay);
    }

    private void OnExitButtonPerformed()
    {
        Application.Quit();
    }
}
