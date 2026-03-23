using UnityEngine;

public class GameMenuSelector : MonoBehaviour
{
    public GameObject[] games;
    public float moveWidth = 20f;
    public float moveSpeed = 10f;
    private int currentIndex = 0;

    private Vector3 centerPosition;
    private Vector3 leftPosition;
    private Vector3 rightPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        centerPosition = new Vector3(0, -1, 0);
        leftPosition = new Vector3(-moveWidth, -1, 0);
        rightPosition = new Vector3(moveWidth, -1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentIndex = (currentIndex + 1) % menuItems.Length;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentIndex -= 1;
            if (currentIndex < 0)
            {
                currentIndex += menuItems.Length;
            }
        }
    }

    private IEnumerator SwitchMenuItem(int oldIndex, int newIndex, bool movingRight)
    {
        
    }
}
