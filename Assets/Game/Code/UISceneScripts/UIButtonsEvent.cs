using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonsEvent : MonoBehaviour
{
    public void SetToggleSound(Toggle toggle)
    {
        toggle.isOn = GameManager.playSounds;
    }
    public void SetBooleanSound(bool arePlaying)
    {
        GameManager.playSounds = arePlaying;
    }
    public void SetSliderValue(Slider setTo)
    {
        SoundsManager sounds = FindObjectOfType<SoundsManager>();
        sounds.GetCurrentValueVolume(setTo);
    }
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
