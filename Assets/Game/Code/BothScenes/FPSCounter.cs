using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    private float pollingTime = 0.75f;
    private float time;
    private float frameCount;
    
    private TextMeshProUGUI fpsText;
    void Awake()
    {
        if (GameManager.fpsCheck)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);

        fpsText = GetComponent<TextMeshProUGUI>();
    }
    
    void Update ()
    {
        time += Time.unscaledDeltaTime;

        frameCount++;

        if (time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            fpsText.text = "FPS: " + frameRate;

            time -= pollingTime;
            frameCount = 0;
        }
    }
}
