using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movavble : MonoBehaviour
{
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
