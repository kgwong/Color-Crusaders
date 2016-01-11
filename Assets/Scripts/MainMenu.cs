using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public CanvasGroup HUDCanvas;

    public CanvasGroup howToPlay;
    public CanvasGroup customize;
    public CanvasGroup credits;
    public CanvasGroup quit;

    public AudioListener audioListener;
    public Toggle soundToggle;

    private CanvasGroup canvasGroup;
    private bool hidden;

    void Awake()
    {
        GameInputManager.gameInput = hidden;
        soundToggle.isOn = GlobalSettings.SOUND_ON;
    }

    void Start ()   
    {
        ShowOnly(howToPlay);
        canvasGroup = GetComponent<CanvasGroup>();
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        if (hidden)
        {
            Show(canvasGroup);
            Hide(HUDCanvas);
        }
        else
        {
            Hide(canvasGroup);
            Show(HUDCanvas);
        }
        hidden = !hidden;
        GameInputManager.gameInput = hidden;
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

    public void SetSoundEnabled(bool value)
    {
        GlobalSettings.SetSoundEnabled(value);
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
        canvasGroup.blocksRaycasts = true;
    }

    private void Hide(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
