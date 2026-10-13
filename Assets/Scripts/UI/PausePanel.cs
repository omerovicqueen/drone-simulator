using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    public GameManager gameManager;
    public Button continueButton;
    public Button exitButton;
    
    private void OnEnable()
    {
        continueButton.onClick.AddListener(OnContinueButtonPerformed);
        exitButton.onClick.AddListener(OnExitButtonPerformed);
    }

    private void OnDisable()
    {
        continueButton.onClick.RemoveListener(OnContinueButtonPerformed);
        exitButton.onClick.RemoveListener(OnExitButtonPerformed);
    }

    private void OnContinueButtonPerformed()
    {
        gameManager.ChangeGameState(GameStateType.Gameplay);
        
    }

    private void OnExitButtonPerformed()
    {
        gameManager.ChangeGameState(GameStateType.Onboarding);
    }
}
