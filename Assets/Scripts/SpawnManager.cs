using UnityEngine;

public class SpawnManager : MonoBehaviour
{    
    public static SpawnManager Instance { get; private set; }

    [SerializeField] GameObject playerPrefab;

    private Vector2 spawnPoint;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        spawnPoint = transform.position;
    }

    private void Start()
    {
        Instantiate(playerPrefab, spawnPoint, Quaternion.identity);
    }

    public void Respawn(Transform player)
    {
        player.position = spawnPoint;
    }
}
