using UnityEngine;
using System;

[RequireComponent(typeof(PlayerBallFactory))]
public class SessionData : MonoBehaviour
{
    public PlayerBallFactory PlayerFactory { get; private set; }
    public int GameDifficulty { get;set;}


    private GameState _gameState;
    public GameState GameState 
    { 
        get => _gameState;
        set
        {
            _gameState = value;
            OnGameStateChange?.Invoke(_gameState);
        }
    }

    public Action<GameState> OnGameStateChange;


    private const int EASY_DIFFICULTY = 1; 
    private void Awake()
    {
        PlayerFactory = GetComponent<PlayerBallFactory>();
        GameDifficulty = EASY_DIFFICULTY;
    }
}
public enum GameState
{
    Paused,
    Active
}

