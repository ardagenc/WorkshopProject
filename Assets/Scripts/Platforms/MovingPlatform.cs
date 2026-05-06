using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Hareket")]
    public Transform pointA;
    public Transform pointB;
    public float duration = 2f;
    public bool startAtA = true;

    public Vector2 Delta { get; private set; }

    private float timer;
    private Vector2 lastPosition;

    void Awake()
    {
        lastPosition = transform.position;

        if (!startAtA)
        {
            transform.position = pointB.position;
            lastPosition = pointB.position;
            timer = duration;
        }
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        float t = Mathf.PingPong(timer / duration, 1f);
        float smoothT = Mathf.SmoothStep(0f, 1f, t);
        Vector2 newPos = Vector2.Lerp(pointA.position, pointB.position, smoothT);

        Delta = newPos - lastPosition;
        lastPosition = newPos;
        transform.position = (Vector3)newPos;
    }
}
