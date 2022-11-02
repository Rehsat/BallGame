using Cinemachine;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class PlayerCinemachineCamera : MonoBehaviour
{
    [Inject] private SessionData _sessionData;
    private CinemachineVirtualCamera _playerCamera;

    private void Start()
    {
        _playerCamera = GetComponent<CinemachineVirtualCamera>();
        _sessionData.PlayerFactory.OnNewBallCreated += StartObserveNewPlayer;
    }
    private void StartObserveNewPlayer(PlayerBall newPlayer)
    {
        _playerCamera.Follow = newPlayer.CameraFollowPoint;
    }
    private void OnDisable()
    {
        _sessionData.PlayerFactory.OnNewBallCreated -= StartObserveNewPlayer;
    }
}
