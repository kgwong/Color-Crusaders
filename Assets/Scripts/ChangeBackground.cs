using UnityEngine;
using System.Collections;

public class ChangeBackground : MonoBehaviour {

    private BattleManager battleManager;
    private Camera cam;

    private float fadeSpeed = .5f;

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
        int numReds = battleManager.redFaction.GetNum();
        int numBlues = battleManager.blueFaction.GetNum();
        Faction.Color winningColor = Faction.Color.BLACK;
        float percWinning = 0.0f;

        if (numReds > numBlues)
        {
            percWinning = (numReds - numBlues) / (float)(numBlues + numReds);
            winningColor = Faction.Color.RED;
        }
        else if (numBlues > numReds)
        {
            percWinning = (numBlues - numReds) / (float)(numBlues + numReds);
            winningColor = Faction.Color.BLUE;
        }

        const float maximumNonBlack = 0.15f;
        float lerpAmount = maximumNonBlack * percWinning;
        return Color.Lerp(Color.black, Faction.ToRGB(winningColor), lerpAmount);
    }
}
