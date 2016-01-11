using UnityEngine;
using System.Collections;

public static class GameInputManager {

    //Same as UnityEngine.Input but can be disabled

    public static bool gameInput = true;

    public static bool GetKey(KeyCode keycode)
    {
        return gameInput ? Input.GetKey(keycode) : false; 
    }

    public static bool GetKeyDown(KeyCode keycode)
    {
        return gameInput ? Input.GetKeyDown(keycode) : false;
    }

    public static bool GetKeyUp(KeyCode keycode)
    {
        return gameInput ? Input.GetKeyUp(keycode) : false;
    }

    public static bool GetMouseButton(int button)
    {
        return gameInput ? Input.GetMouseButton(button) : false;
    }
}
