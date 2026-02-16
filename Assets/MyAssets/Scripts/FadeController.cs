using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public float fadeDuration = 1f;

    private Image fadeImage;
    private Color originalColor;

    void Awake()
    {
        fadeImage = GetComponent<Image>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
