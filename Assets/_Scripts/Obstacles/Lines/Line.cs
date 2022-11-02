using UnityEngine;

public class Line : MonoBehaviour
{
    public bool IsDespawned { get;set; }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var target = collision.gameObject.GetComponent<IDieable>();
        if (target != null)
            KillTarget(target);
    }
    private void KillTarget(IDieable target)
    {
        target.Die();
    }
}
