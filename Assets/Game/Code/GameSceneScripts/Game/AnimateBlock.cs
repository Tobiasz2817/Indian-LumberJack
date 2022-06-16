using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class AnimateBlock : MonoBehaviour
{
    private Poller myPoller;

    [SerializeField] 
    private int countAnimateBlock = 10;
    
    [SerializeField]
    private RuntimeAnimatorController  animator;

    private 
    void Awake()
    {
        myPoller = new Poller();
    }
    public void Animate(string inputKey)
    {
        GameObject animationObject = myPoller.GetObject();
        animationObject.SetActive(true);

        Animator localAnim = animationObject.GetComponent<Animator>();
        if (inputKey == "a" || inputKey == "leftArrow")
        {
            localAnim.SetTrigger("Right_Block");
        }
        else if (inputKey == "d" || inputKey == "rightArrow")
        {
            localAnim.SetTrigger("Left_Block");
        }

        StartCoroutine(PollingAfterAnim(animationObject));
    }

    public void CreateAnimatePoller(GameObject treePrefab)
    {
        for (int i = 0; i < countAnimateBlock; i++)
        {
            GameObject tree = Instantiate(treePrefab, new Vector2(treePrefab.transform.position.x,0) , Quaternion.identity, transform);
            tree.AddComponent<Animator>().runtimeAnimatorController = animator;
            tree.SetActive(false);
            myPoller.Add(tree);
        }
    }
    
    private IEnumerator PollingAfterAnim(GameObject disableGO)
    {
        yield return new WaitForSeconds(0.19f);
        myPoller.PoolObject(disableGO);
    }
}
