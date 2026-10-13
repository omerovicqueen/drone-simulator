using UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject onboardingUI;
    public GameObject pauseUI;
    public GameObject completeUI;
    public GameObject gameplayPanel;
    
    void Start()
    {
        gameManager.onGameStateChanged += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        gameManager.onGameStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameStateType gameStateType)
    {
        if (gameStateType == GameStateType.GameOver)
        {
            gameplayPanel.SetActive(false);
            completeUI.SetActive(true);
            onboardingUI.SetActive(false);
            pauseUI.SetActive(false);
        }
        else if (gameStateType == GameStateType.Onboarding)
        {
            gameplayPanel.SetActive(false);
            onboardingUI.SetActive(true);
            completeUI.SetActive(false);
            pauseUI.SetActive(false);
        }
        else if (gameManager.gameStateType == GameStateType.Gameplay)
        {
            gameplayPanel.SetActive(true);
            onboardingUI.SetActive(false);
            completeUI.SetActive(false);
            pauseUI.SetActive(false);
        }
        else if (gameManager.gameStateType == GameStateType.Paused)
        {
            gameplayPanel.SetActive(false);
            pauseUI.SetActive(true);
            onboardingUI.SetActive(false);
            completeUI.SetActive(false);
        }
    }
}
