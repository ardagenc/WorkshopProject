using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public void Die()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

        SpawnManager.Instance.Respawn(transform);
    }
}
