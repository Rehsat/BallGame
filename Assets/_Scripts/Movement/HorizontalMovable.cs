using UnityEngine;

public class HorizontalMovable : Movavble
{
    public void MoveHorizontal(float speedScale)
    {
         Move(new Vector2(speedScale * Speed * Time.fixedDeltaTime, MyRigidbody.velocity.y));
    }
}
