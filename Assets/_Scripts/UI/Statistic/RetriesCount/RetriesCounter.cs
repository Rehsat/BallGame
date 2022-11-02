using System;
using UnityEngine;
using Zenject;

public class RetriesCounter : MonoBehaviour
{

    [Inject] private SessionData _sessionData; 

    private int _retriesCount;
    public int RetriesCount
    { 
        get => _retriesCount;
        private set
        {
            _retriesCount = value;
            SaveRetriesCount(_retriesCount, "retries");
            OnRetriesCountValueChange?.Invoke(RetriesCount);
        } 
    }
    public Action<int> OnRetriesCountValueChange;

    private void Start()
    {
        _sessionData.OnGameStateChange += TryCountTry;
    }
    private void SaveRetriesCount(int value, string key)
    {
        PlayerPrefs.SetFloat(key, value);
    }
    private void TryCountTry(GameState state)
    {
        if (state == GameState.Paused)
        {
            var previousRetriesCoint = PlayerPrefs.GetFloat("retries", 0);
            RetriesCount = (int)previousRetriesCoint + 1;
        }
    }
    private void OnDestroy()
    {

        _sessionData.OnGameStateChange -= TryCountTry;
    }

}
