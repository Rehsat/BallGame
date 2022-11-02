using UnityEngine;

public class VerticalMovable : Movavble
{
    public void MoveVertical()
    {
        Move(new Vector2(MyRigidbody.velocity.x, Speed * Time.fixedDeltaTime));
    }
}
