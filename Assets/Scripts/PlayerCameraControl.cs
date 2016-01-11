using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerCameraControl : MonoBehaviour {

    public float panSpeed;
    public CanvasGroup spectatorModeText;

    private FollowShip followShip;
    private bool spectatorMode = true;
    private AudioSource audioSource;

    void Start()
    {
        followShip = GetComponent<FollowShip>();
        audioSource = GetComponent<AudioSource>();
    }

	void Update ()
    {
        if (spectatorMode)
        {
            SpectatorModeControls();
        }

        if (GameInputManager.GetKeyDown(KeyCode.R))
        {
            GameObject.Find("BattleManager").GetComponent<BattleManager>().Restart();
        }
    }

    private void SpectatorModeControls()
    {

        if (GameInputManager.GetKey(KeyCode.LeftArrow))
        {
            PanCamera(Vector3.left);
        }
        if (GameInputManager.GetKey(KeyCode.RightArrow))
        {
            PanCamera(Vector3.right);
        }
        if (GameInputManager.GetKey(KeyCode.UpArrow))
        {
            PanCamera(Vector3.up);
        }
        if (GameInputManager.GetKey(KeyCode.DownArrow))
        {
            PanCamera(Vector3.down);
        }

        if (GameInputManager.GetMouseButton(0))
        {
            Ship s = followShip.GetCurrentShip();
            if (s != null)
            {
                PosessShip(s);
            }
        }

        if (GameInputManager.GetKeyDown(KeyCode.Space))
        {
            followShip.StartCoroutine("GetNewShipDelay", 0);
        }
    }

    public void SetSpectatorMode(bool value)
    {
        spectatorMode = value;
        spectatorModeText.alpha = value ? 1 : 0;
        spectatorModeText.interactable = value;
    }

    private void PanCamera(Vector3 direction)
    {
        transform.position += direction * panSpeed * Time.deltaTime;
        followShip.enabled = false;
    }

    private void PosessShip(Ship ship)
    {
        ship.ChangeController<PlayerController>();
        StartCoroutine(PosessShipEffect(ship));
        SetSpectatorMode(false);
        audioSource.Play();
    }

    private IEnumerator PosessShipEffect(Ship ship)
    {
        SpriteRenderer renderer = ship.GetComponent<SpriteRenderer>();
        Color originalColor = renderer.color;
        renderer.color = Color.white;
        float time = 0f;
        while (time < .95f)
        {
            time += Time.deltaTime;
            if (renderer == null)
            {
                //ship may be destroyed while still fading
                yield break; 
            }
            renderer.color = Color.Lerp(Color.white, originalColor, time);
            yield return null;
        }
        renderer.color = originalColor;
    }
}
