using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public InputManager inputManager;
    public GameStateType gameStateType;
    public List<Checkpoint> checkpoints = new ();
    public ParticleSystem particles;

    public bool isGameRunning;
    public bool isGameSuccessful;
    public bool isContinue;
    public Drone drone;
    public Transform startPoint;
    public Action OnCheckpointsChanged;
    public Action<GameStateType> onGameStateChanged;
    public float timeTaken;

    void Start()
    {
        inputManager.onPausePressed += OnPausePressed;

        ChangeGameState(GameStateType.Onboarding);
    }

    private void OnDestroy()
    {
        inputManager.onPausePressed -= OnPausePressed;
    }

    private void OnPausePressed()
    {
        if (gameStateType == GameStateType.Paused)
        {
            ChangeGameState(GameStateType.Gameplay);
        }
        else if (gameStateType == GameStateType.Gameplay)
        {
            ChangeGameState(GameStateType.Paused);
        }
    }

    public void ChangeGameState(GameStateType newGameState)
    {
        gameStateType = newGameState;
        onGameStateChanged?.Invoke(gameStateType);

        if (isGameRunning == false)
        {
            if (gameStateType == GameStateType.Gameplay)
            {
                if(isContinue == false)
                {
                    ResetGame();
                    StartGame();
                    
                }

                else 
                {
                    drone.OnReset();
                    StartGame();
                    isContinue = false;
                    
                }
                
            }

            if (gameStateType == GameStateType.Onboarding)
            {
                drone.OnReset();
                ResetGame();
                isContinue = false;
                
            }
        }
        else
        {
            if (gameStateType == GameStateType.GameOver)
            {
                ResetGame();
                if (isGameSuccessful == true)
                {
                    particles.Play();
                }
            }

            if (gameStateType == GameStateType.Paused)
            {
                drone.OnReset();
                isGameRunning = false;
                isContinue =true;
            }

            if (gameStateType == GameStateType.Onboarding)
            {
                ResetGame();
                isContinue = false;

            }
            
            
        }
    }

    private void StartGame()
    {
        isGameRunning = true;
        drone.OnGameplay();
        
    }

    private void ResetGame()
    {
        isGameRunning = false;
        drone.OnReset();
        drone.transform.position = startPoint.position;
        drone.transform.rotation = startPoint.rotation;

        foreach (var checkpoint in checkpoints)
        {
            checkpoint.model.SetActive(true);
            checkpoint.col.enabled = true;
            checkpoint.isTriggered = false;
        }
    }

    public void OnCheckpointStateChanged()
    {
        foreach (var checkpoint in checkpoints)
        {
            if (checkpoint.isTriggered == false)
            {
                return;
            }
        }
        OnGameEnd(true);
        ChangeGameState(GameStateType.GameOver);
    }

    public void OnGameEnd(bool isSuccessful)
    {
        isGameSuccessful = isSuccessful;
    }
}
