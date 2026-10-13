using TMPro;
using UnityEngine;

namespace UI
{
    public class GameplayPanel : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private TMP_Text checkpointsText;
        [SerializeField] private float startTime = 20f;
        
        private float currentTime;
        private bool isFinished;

        void Start()
        {
            currentTime = startTime;
            
        }
        
        private void OnEnable()
        {
            gameManager.OnCheckpointsChanged += UpdateCheckpointText;
            ResetTime();
            
            isFinished = false;
        }

        private void OnDisable()
        {
            gameManager.OnCheckpointsChanged -= UpdateCheckpointText;
            

        }

        private void UpdateCheckpointText()
        {
            int totalcheck = 0;
            int checkpointsayi = gameManager.checkpoints.Count;
            foreach (var checkpoint in gameManager.checkpoints)
            {
                if (checkpoint.isTriggered == true)
                {
                    totalcheck++;
                }
            }

            if (checkpointsText.text != null)
            {
                checkpointsText.text = "Checkpoints:    " + totalcheck +"/"+ checkpointsayi ;
            }
        }

        private void Update()
        {
            UpdateCheckpointText();
            OnTimeUpdate();
            gameManager.timeTaken = startTime - currentTime;
        }

        private void OnTimeUpdate()
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                if (isFinished == false)
                {
                    OnTimerFinished();
                }
            }
            else
            {
                UpdateText();
            }
        }

        private void ResetTime()
        {
            if (gameManager.isContinue == false)
            {
                currentTime = startTime;
            }
        }
        

        private void OnTimerFinished()
        {
            isFinished = true;
            currentTime = 0;
            UpdateText();

            gameManager.OnGameEnd(false);
            gameManager.ChangeGameState(GameStateType.GameOver);
        }

        private void UpdateText()
        {
            timerText.text = Mathf.CeilToInt(currentTime).ToString();
        }
    }
}
