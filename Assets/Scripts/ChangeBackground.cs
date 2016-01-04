using UnityEngine;
using System.Collections;

public class ChangeBackground : MonoBehaviour {

    private BattleManager battleManager;
    private Camera cam;

    private float fadeSpeed = .5f;
    private const float maximumColorPercent = 0.15f;

	void Start ()
    {
        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        cam = GetComponent<Camera>();
	}
	
	void Update ()
    {
        float fade = Time.deltaTime * fadeSpeed;
        cam.backgroundColor = Color.Lerp(cam.backgroundColor, GetGoalColor(), fade);
    }

    private Color GetGoalColor()
    {
        Faction winning = battleManager.GetWinningFaction();
        float percWinning = 0f;
        Color winningColor = Color.black;
        if (winning != null)
        {
            percWinning = winning.GetNum() / (float)battleManager.GetTotalShips();
            winningColor = winning.GetRGB();
        }

        float lerpAmount = maximumColorPercent * percWinning;
        return Color.Lerp(Color.black, winningColor, lerpAmount);
    }
}
