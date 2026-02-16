using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuSelector : MonoBehaviour
{
    public TMP_Text[] menuItems;

    public Color normalColor = Color.white;
    public Color highlightColor = Color.red;

    private int currentIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateColors();
    }

    // Update is called once per frame
    void Update()
    {
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
        else if (menuItems[index].text == "games")
        {
            SceneManager.LoadScene("GameMenu");
        }
        else if (menuItems[index].text == "settings")
        {
            SceneManager.LoadScene("Settings");
        }
    }
}
