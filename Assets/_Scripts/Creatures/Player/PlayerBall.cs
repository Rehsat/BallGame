using System;
using UnityEngine;

[RequireComponent(typeof(HorizontalMovable))]
[RequireComponent (typeof(VerticalMovable))]
public class PlayerBall : MonoBehaviour, IDieable
{
    [SerializeField] private Transform _cameraFollowPoint;
    [SerializeField] private LinesFactory _linesFactory;

    private SessionData _sessionData;
    private HorizontalMovable _horizontalMover;

    private float _horizontalMoveScale;

    public VerticalMovable MyVerticalMover { get; private set;}
    public Transform CameraFollowPoint => _cameraFollowPoint;
    public Action<PlayerBall> OnDie;

    private bool _moveVertical;
    private void OnEnable()
    {
        MyVerticalMover = GetComponent<VerticalMovable>();
        _horizontalMover = GetComponent<HorizontalMovable>();
    }
    public void Init(float horizontalMoveScale, SessionData sessionData)
    {
        _sessionData = sessionData;
        _horizontalMoveScale = horizontalMoveScale;
        _linesFactory.Init(_sessionData);
    }
    private void FixedUpdate()
    {
        _horizontalMover.MoveHorizontal(_horizontalMoveScale);
        if(_moveVertical)
            MyVerticalMover.MoveVertical();
    }
    public void Die()
    {
        _sessionData.GameState = GameState.Paused;
        OnDie?.Invoke(this);
    }
    public void SetMoveVerticalState(bool state)
    {
        _moveVertical = state;
    }
}
