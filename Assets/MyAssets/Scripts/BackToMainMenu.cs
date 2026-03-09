using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    public FadeController fader;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(ChangeToMyScene("MainMenu"));
        }
    }
    
    private System.Collections.IEnumerator ChangeToMyScene(string sceneName)
    {
        fader.FadeIn();
        yield return new WaitForSeconds(fader.fadeDuration);
        SceneManager.LoadScene(sceneName);
    } 
}
