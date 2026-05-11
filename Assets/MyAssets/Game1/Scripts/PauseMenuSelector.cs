using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseMenuSelector : MonoBehaviour
{
    public TMP_Text[] menuItems;

    public Color normalColor = Color.white;
    public Color highlightColor = Color.red;

    private int currentIndex = 0;
    private bool isPaused = false;

    public FadeController fader;
    public GameObject pauseMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        UpdateColors();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (!isPaused) return;

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentIndex = (currentIndex + 1) % menuItems.Length;
            UpdateColors();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentIndex -= 1;
            if (currentIndex < 0)
            {
                currentIndex += menuItems.Length;
            }
            UpdateColors();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ActivateItem(currentIndex);
        }
    }

    void UpdateColors()
    {
        for (int i = 0; i < menuItems.Length; i++)
        {
            if (i == currentIndex)
            {
                menuItems[i].color = highlightColor;
            }
            else
            {
                menuItems[i].color = normalColor;
            }
        }
    }

    void ActivateItem(int index)
    {
        Debug.Log("Aktivoitu: " + menuItems[index].text);
        if (menuItems[index].text == "quit")
        {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        else if (menuItems[index].text == "main menu")
        {
            StartCoroutine(ChangeToMyScene("MainMenu"));
        }
        else if (menuItems[index].text == "resume game")
        {
            Debug.Log("RESUME GAME");
        }
    }

    private System.Collections.IEnumerator ChangeToMyScene(string sceneName)
    {
        fader.FadeIn();
        yield return new WaitForSeconds(fader.fadeDuration);
        SceneManager.LoadScene(sceneName);
    }

    void PauseGame()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
    }

    void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
    }
}
