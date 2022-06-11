using UnityEngine;
using UnityEngine.UI;

public class PlayerTime : MonoBehaviour
{
    [SerializeField]
    private float speedTime = 5f;
    
    private float currentTime = 1;
    
    private Image currentTimeUI;
    void Start()
    {
        currentTimeUI = GetComponent<Image>();
    }
    
    void Update()
    {
        if (GameManager.GameOver) return;
        
        currentTime -= (Time.deltaTime * speedTime) / 100;
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
            currentTime += (Time.deltaTime * increaseTime);
    }
}
