using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonsEvent : MonoBehaviour
{
    public void Play()
    {
        FindObjectOfType<LevelLoader>().LoadLevelByIndex(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        Application.Quit();
    }
    
    
}
