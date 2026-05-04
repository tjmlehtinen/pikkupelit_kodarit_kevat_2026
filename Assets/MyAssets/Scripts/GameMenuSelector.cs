using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuSelector : MonoBehaviour
{
    public GameObject[] menuItems;
    public FadeController fader;
    private float moveWidth = 15f;
    private float moveSpeed = 15f;
    private int currentIndex = 0;

    private Vector3 centerPosition;
    private Vector3 leftPosition;
    private Vector3 rightPosition;

    private bool isMoving = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        centerPosition = new Vector3(0, -1, 0);
        leftPosition = new Vector3(-moveWidth, -1, 0);
        rightPosition = new Vector3(moveWidth, -1, 0);
        for (int i = 0; i < menuItems.Length; ++i)
        {
            if (i == currentIndex)
            {
                menuItems[i].transform.position = centerPosition;
                menuItems[i].SetActive(true);
            }
            else
            {
                menuItems[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        int oldIndex = currentIndex;
        if (!isMoving && Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentIndex = (currentIndex + 1) % menuItems.Length;
            StartCoroutine(SwitchMenuItem(oldIndex, currentIndex, true));
        }
        if (!isMoving && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentIndex -= 1;
            if (currentIndex < 0)
            {
                currentIndex += menuItems.Length;
            }
            StartCoroutine(SwitchMenuItem(oldIndex, currentIndex, false));
        }
        if (!isMoving && Input.GetKeyDown(KeyCode.Return))
        {
            StartGame(currentIndex);
        }
    }

    private System.Collections.IEnumerator SwitchMenuItem(int oldIndex, int newIndex, bool movingRight)
    {
        isMoving = true;
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
            yield return null;
        }

        newMenuItem.transform.position = centerPosition;
        oldMenuItem.SetActive(false);
        isMoving = false;
    }
    private void StartGame(int index)
    {
        if (index == 0)
        {
            StartCoroutine(ChangeToMyScene("Game1"));
        }
    }

    private System.Collections.IEnumerator ChangeToMyScene(string sceneName)
    {
        fader.FadeIn();
        yield return new WaitForSeconds(fader.fadeDuration);
        SceneManager.LoadScene(sceneName);
    } 
}
