using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        PlayerDeath death = col.GetComponent<PlayerDeath>();
        if (death != null)
            death.Die();
    }
}
