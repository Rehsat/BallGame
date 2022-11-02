using UnityEngine;
using System;
using Zenject;

public class PlayerBallFactory : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private PlayerBall _ballPrefab;

    [Inject] private SessionData _sessionController;

    public Action<PlayerBall> OnNewBallCreated;
    public void CreateBall()
    {
        var newBall = Instantiate(_ballPrefab, _spawnPosition.position, Quaternion.identity);
        newBall.Init(_sessionController.GameDifficulty);
        OnNewBallCreated?.Invoke(newBall);
    }
}
