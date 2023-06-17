using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState gameState; 

    private void Awake()
    {
        instance = this;
    }
    

    public void UpdateGameState(GameState newState)
    {
        gameState = newState;

        switch (newState)
        {
            case GameState.Intro:
                break;
            case GameState.QuestsVillage: break;
            case GameState.Dialogue: break;
            case GameState.Cutscene: break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
}


public enum GameState
{
    Intro,
    QuestsVillage,
    Dialogue,
    Cutscene
    
}