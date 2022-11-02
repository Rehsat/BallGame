using System.Collections;
using System;
using UnityEngine;
using Zenject;

public class TimeCounter : MonoBehaviour
{
    [Inject] private SessionData _sessionData;
    public int Seconds { get; private set; }
    private void Awake()
    {
        _sessionData.OnGameStateChange += ChangeCountStateByGameState;
    }
    private void ChangeCountStateByGameState(GameState state)
    {
        if(state == GameState.Active)
        {
            StartCoroutine(Counting());
            Seconds = 0;
        }
        else
        {
            StopAllCoroutines();
        }
    }
    private IEnumerator Counting()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            Seconds++;
        }
    }
    private void OnDestroy()
    {
        _sessionData.OnGameStateChange -= ChangeCountStateByGameState;
    }
}
