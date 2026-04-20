using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 nextPosition = transform.position;
        nextPosition.x += horizontalInput * moveSpeed * Time.deltaTime;
        transform.position = nextPosition;
    }
}
