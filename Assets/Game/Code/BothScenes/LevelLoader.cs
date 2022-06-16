using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    [SerializeField] 
    private Animator transition;

    [SerializeField]
    private float timeTranisiton;

    public void LoadLevelByIndex(int index)
    {
        StartCoroutine(LoadLevel(index));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        
        yield return new WaitForSeconds(timeTranisiton);
        SceneManager.LoadScene(levelIndex);
        GameManager.GameOver = false;
    }

    public bool IsLoaded()
    {
        return !AnimationManager.IsPlaying(transition,"Transition_end_UI");
    }

}
