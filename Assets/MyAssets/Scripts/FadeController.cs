using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public float fadeDuration = 1f;

    private Image fadeImage;
    private Color originalColor;
    private Coroutine currentRoutine;

    void Awake()
    {
        fadeImage = GetComponent<Image>();
        originalColor = fadeImage.color;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FadeOut();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FadeOut() => StartFade(0f);
    public void FadeIn() => StartFade(originalColor.a);
    void StartFade(float targetAlpha)
    {
        if (currentRoutine != null)
        {
            StopCoroutine(currentRoutine);
        }
        currentRoutine = StartCoroutine(FadeRoutine(targetAlpha));
    }
    private System.Collections.IEnumerator FadeRoutine(float targetAlpha)
    {
        float time = 0f;
        float startAlpha = fadeImage.color.a;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float t = time / fadeDuration;
            Color tempColor = fadeImage.color;
            tempColor.a = Mathf.Lerp(startAlpha, targetAlpha, t);
            fadeImage.color = tempColor;
            yield return null;
        }
        Color finalColor = fadeImage.color;
        finalColor.a = targetAlpha;
        fadeImage.color = finalColor;
    }
}
