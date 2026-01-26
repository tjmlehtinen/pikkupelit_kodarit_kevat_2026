using UnityEngine;
using TMPro;

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
}
