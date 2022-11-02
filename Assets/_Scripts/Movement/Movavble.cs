using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movavble : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed = Mathf.Infinity;
    public float Speed 
    { 
        get => _speed;
        set
        {
            _speed = Mathf.Clamp(value, _minSpeed, _maxSpeed);
        }
    }

    protected Rigidbody2D MyRigidbody;
    private void OnEnable()
    {
        MyRigidbody = GetComponent<Rigidbody2D>();
    }
    protected void Move(Vector2 movement)
    {
        MyRigidbody.velocity = movement;
    }
}
