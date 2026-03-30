using UnityEngine;

public class GameMenuSelector : MonoBehaviour
{
    public GameObject[] menuItems;
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
        int oldIndex = currentIndex;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentIndex = (currentIndex + 1) % menuItems.Length;
            StartCoroutine(SwitchMenuItem(oldIndex, currentIndex, true));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentIndex -= 1;
            if (currentIndex < 0)
            {
                currentIndex += menuItems.Length;
            }
            StartCoroutine(SwitchMenuItem(oldIndex, currentIndex, false));
        }
    }

    private System.Collections.IEnumerator SwitchMenuItem(int oldIndex, int newIndex, bool movingRight)
    {
        GameObject oldMenuItem = menuItems[oldIndex];
        GameObject newMenuItem = menuItems[newIndex];

        Vector3 targetForOld = movingRight ? rightPosition : leftPosition;
        Vector3 startForNew = movingRight ? leftPosition : rightPosition;

        newMenuItem.transform.position = startForNew;
        newMenuItem.SetActive(true);

        while (Vector3.Distance(newMenuItem.transform.position, centerPosition) > 0.01f)
        {
            oldMenuItem.transform.position = Vector3.MoveTowards(oldMenuItem.transform.position, targetForOld, moveSpeed * Time.deltaTime);
            newMenuItem.transform.position = Vector3.MoveTowards(newMenuItem.transform.position, centerPosition, moveSpeed * Time.deltaTime);
        }
        oldMenuItem.SetActive(false);
        yield return null;
    }
}
