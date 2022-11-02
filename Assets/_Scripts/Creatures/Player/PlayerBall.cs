using UnityEngine;

[RequireComponent(typeof(HorizontalMovable))]
[RequireComponent (typeof(VerticalMovable))]
public class PlayerBall : MonoBehaviour
{
    [SerializeField] private Transform _cameraFollowPoint;
    private HorizontalMovable _horizontalMover;
    private float _horizontalMoveScale;

    public VerticalMovable MyVerticalMover { get; private set;}
    public Transform CameraFollowPoint => _cameraFollowPoint;

    private bool _moveVertical;
    private void OnEnable()
    {
        MyVerticalMover = GetComponent<VerticalMovable>();
        _horizontalMover = GetComponent<HorizontalMovable>();
    }
    public void Init(float horizontalMoveScale)
    {
        _horizontalMoveScale = horizontalMoveScale;
    }
    private void FixedUpdate()
    {
        _horizontalMover.MoveHorizontal(_horizontalMoveScale);
        if(_moveVertical)
            MyVerticalMover.MoveVertical();
    }
    public void SetMoveVerticalState(bool state)
    {
        _moveVertical = state;
    }
}
