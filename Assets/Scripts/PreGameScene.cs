using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PreGameScene : MonoBehaviour {

	public void OnSoundToggle(bool value)
    {
        GlobalSettings.SOUND_ON = value;
    }

    public void OnContinuePressed()
    {
        SceneManager.LoadScene("color_crusaders");
    }
}
