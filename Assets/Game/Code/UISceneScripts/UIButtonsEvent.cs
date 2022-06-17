using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonsEvent : MonoBehaviour
{
    public void SetToggleBooleanIsOn(Toggle toggle)
    {
        toggle.isOn = GameManager.fpsCheck;
    }
    public void CheckFPS(bool startCheck)
    {
        GameManager.fpsCheck = startCheck;
    }
    public void Play()
    {
        FindObjectOfType<LevelLoader>().LoadLevelByIndex(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
