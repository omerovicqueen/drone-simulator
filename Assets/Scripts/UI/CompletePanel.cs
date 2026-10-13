using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CompletePanel : MonoBehaviour
    {
        public GameManager gameManager;
        public PlayerScoreBoardManager playerScoreBoard;
        public GameObject subPanel;
        [SerializeField] private TMP_InputField nameInputField;
        [SerializeField] private TMP_Text resultText;
        public Button restartButton;
        public Button backButton;
        public Button saveButton;

        public void OnEnable()
        {
            restartButton.onClick.AddListener(OnRestartButtonPressed);
            backButton.onClick.AddListener(OnBackButtonPressed);
            saveButton.onClick.AddListener(OnSaveButtonPressed);
            

            if (gameManager.isGameSuccessful)
            {
                resultText.text = "You Win!";
                subPanel.SetActive(true);
                saveButton.interactable = true;
                
            }
            else
            {
                resultText.text = "You Lose!";
                subPanel.SetActive(false);
            }
        }

        public void OnDisable()
        {
            restartButton.onClick.RemoveAllListeners();
            backButton.onClick.RemoveAllListeners();
            saveButton.onClick.RemoveAllListeners();

        }
    
        private void OnRestartButtonPressed()
        {
            gameManager.ChangeGameState(GameStateType.Gameplay);
        }

        private void OnBackButtonPressed()
        {   
            gameManager.ChangeGameState(GameStateType.Onboarding);
        }

        private void OnSaveButtonPressed()
        {
            string savedName =  nameInputField.text;
            if (string.IsNullOrEmpty(savedName))
            {
                return;
            }

            float finisTime = gameManager.timeTaken;
            saveButton.interactable = false;
            playerScoreBoard.SaveScoreBoard(savedName, finisTime);
        }
    }
}
