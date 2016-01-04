using UnityEngine;
using System.Collections;

public class FactionEditor : MonoBehaviour {

    public struct Settings
    {
        public bool enabled;
        public Color color;
        public string name;
        public int numUnits;
    }

    public Settings GetSettings(int index)
    {
        FactionEditorPanel panel = transform.GetChild(index).GetComponent<FactionEditorPanel>();
        Settings s = new Settings();
        s.enabled = panel.enableFaction;
        s.color = panel.color;
        s.name = panel.optionalName;
        s.numUnits = panel.numUnits;
        return s;
    }
}
