using System.Collections;
using System.Collections.Generic;
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
    
}
