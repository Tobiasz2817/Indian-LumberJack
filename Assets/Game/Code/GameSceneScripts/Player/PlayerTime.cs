using UnityEngine;
using UnityEngine.UI;

public class PlayerTime : MonoBehaviour
{
    private float speedTime = 10f;
    
    private float currentTime = 1;
    private float currentDeltaTime = 0;
    
    private Image currentTimeUI;
    private LevelLoader levelLoader;
    void Start()
    {
        currentTimeUI = GetComponent<Image>();
        levelLoader = FindObjectOfType<LevelLoader>();

        if (!levelLoader || !currentTimeUI) this.enabled = false;

        speedTime = (float)GameManager.currentDiff;
    }
    
    void FixedUpdate()
    {
        if (GameManager.GameOver || !levelLoader.IsLoaded()) return;

        currentDeltaTime = Time.deltaTime;
        
        currentTime -= (currentDeltaTime * speedTime) / 100;
        currentTimeUI.fillAmount = currentTime;
        
        if (currentTimeUI.fillAmount <= 0)
        {
            FindObjectOfType<PlayerHealth>().GameOver();
            this.enabled = false;
        }
    }

    public void UpdateTime(float increaseTime)
    {
        if(currentTime < 1)
            currentTime += (currentDeltaTime * increaseTime) / 10;
    }
}
