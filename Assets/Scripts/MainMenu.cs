using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public CanvasGroup howToPlay;
    public CanvasGroup customize;
    public CanvasGroup credits;
    public CanvasGroup quit;

	void Start ()
    {
        ShowOnly(howToPlay);
	}
	
	void Update ()
    {
	
	}

    public void OnHowToPlayPressed()
    {
        ShowOnly(howToPlay);
    }

    public void OnCustomizePressed()
    {
        ShowOnly(customize);
    }

    public void OnCreditsPressed()
    {
        ShowOnly(credits);
    }

    public void OnQuitPressed()
    {
        ShowOnly(quit);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void ShowOnly(CanvasGroup canvasGroup)
    {
        Hide(howToPlay);
        Hide(customize);
        Hide(credits);
        Hide(quit);
        Show(canvasGroup);
    }

    private void Show(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
    }

    private void Hide(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
    }
}
