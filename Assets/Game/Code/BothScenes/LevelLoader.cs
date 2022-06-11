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
        return !IsPlaying(transition,"Transition_end_UI");
    }
    bool IsPlaying(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }
}
