using UnityEngine;

public class BallController : MonoBehaviour
{
    public float startSpeed = 5f;
    private Rigidbody2D body;
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Launch();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Launch()
    {
        body.linearVelocity = Vector2.zero;
        Vector2 direction = new Vector2(Random.Range(-0.7f, 0.7f), 1f).normalized;
        body.linearVelocity = direction * startSpeed;
    }
}
