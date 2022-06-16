using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] 
    private GameObject panelUI;

    private PlayerInput playerInput;
    private LevelLoader levelLoader;

    private void Start()
    {
        panelUI.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text =  "High score: " + FindObjectOfType<Database>().GetScore((int)GameManager.currentDiff);

        playerInput = FindObjectOfType<PlayerInput>();
        levelLoader = FindObjectOfType<LevelLoader>();
    }

    public void Pause(InputAction.CallbackContext hit)
    {
        if (hit.action.triggered && !panelUI.activeInHierarchy && levelLoader.IsLoaded())
        {
            Time.timeScale = 0.0f;
            panelUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Pause";
            panelUI.SetActive(true);
            playerInput.enabled = false;
        }
    }

    public void UnPause()
    {
        Time.timeScale = 1.0f;
        playerInput.enabled = true;
    }

    public void BackToMenu()
    {
        FindObjectOfType<LevelLoader>().LoadLevelByIndex(SceneManager.GetActiveScene().buildIndex - 1);
        UnPause();
    }
    public void Restart()
    {
        FindObjectOfType<LevelLoader>().LoadLevelByIndex(SceneManager.GetActiveScene().buildIndex);
        UnPause();
    }
}
