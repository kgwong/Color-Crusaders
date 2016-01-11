using UnityEngine;
using System.Collections;

public class GlobalSettings : MonoBehaviour {

    public static bool SOUND_ON = true;

    void Start()
    {
        SetSoundEnabled(SOUND_ON);
    }

    public static void SetSoundEnabled(bool value)
    {
        AudioListener.pause = !value;
    }
}

