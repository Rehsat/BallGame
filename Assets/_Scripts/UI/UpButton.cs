using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

[RequireComponent(typeof(EventTrigger))]
public class UpButton : MonoBehaviour
{
    private PlayerBall _player;

    [Inject] private SessionData _sessionData;

    private void OnEnable()
    {
        _sessionData.PlayerFactory.OnNewBallCreated += SetNewPlayer;
    }
    private void SetNewPlayer(PlayerBall newPlayer)
    {
        _player = newPlayer;
    }
    public void SetPlayerVerticalMovementState(bool state)
    {
        if (_player != null)
            _player.SetMoveVerticalState(state);
    }
    private void OnDisable()
    {
        _sessionData.PlayerFactory.OnNewBallCreated -= SetNewPlayer;
    }
}
