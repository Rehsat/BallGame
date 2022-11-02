using UnityEngine;
using System;
using Zenject;
[RequireComponent(typeof(PlayerBallPool))]
public class PlayerBallFactory : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private PlayerBall _ballPrefab;

    [Inject] private SessionData _sessionController;

    public Action<PlayerBall> OnNewBallCreated;

    private PlayerBall _currentPlayerBall;
    private PlayerBallPool _playerBallsPool;
    private void Awake()
    {
        _playerBallsPool = GetComponent<PlayerBallPool>();
    }
    public void CreateBall()
    {
        var newBall = _playerBallsPool.Spawn(_ballPrefab, _spawnPosition, Quaternion.identity);

        newBall.Init(_sessionController.GameDifficulty, _sessionController);

        newBall.OnDie += DespawnBall;
        _currentPlayerBall = newBall;

        OnNewBallCreated?.Invoke(newBall);
    }
    private void DespawnBall(PlayerBall ball)
    {
        _currentPlayerBall.OnDie -= DespawnBall;
        _playerBallsPool.Despawn(ball);
    }
}
