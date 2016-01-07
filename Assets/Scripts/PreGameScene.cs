using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PreGameScene : MonoBehaviour {

	public void OnMusicOnToggle(bool value)
    {
        GlobalSettings.MUSIC_ON = value;
    }

    public void OnSoundEffectsOnToggle(bool value)
    {
        GlobalSettings.SOUND_EFFECTS_ON = value;
    }

    public void OnContinuePressed()
    {
        SceneManager.LoadScene("color_crusaders");
    }
}
