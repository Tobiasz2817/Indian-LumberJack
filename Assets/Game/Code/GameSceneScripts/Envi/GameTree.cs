using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameTree : MonoBehaviour
{
    [SerializeField]
    private GameObject treePrefab;
    [SerializeField]
    private GameObject branchPrefab;

    [SerializeField] 
    private int countTree = 30;

    private float sizeScreenY;
    public Poller PollerTree { get; private set; }
    
    private void Awake()            
    {
        PollerTree = new Poller();
    }

    private void Start()
    {
        CreateTree(countTree);
        
        Camera camera = Camera.main;
        sizeScreenY = camera.ScreenToWorldPoint(new Vector2(camera.pixelWidth,camera.pixelHeight)).y;
    }

    private void CreateTree(int countTree)
    {
        if (PollerTree == null)
        {
            Debug.LogError(" Poller are null ");
            return;
        }

        for (int i = 0; i < countTree; i++)
        {
            GameObject tree = Instantiate(treePrefab, new Vector2(0,i) , Quaternion.identity, transform);
            PollerTree.CreatePoller(tree);
        }
        
        CreateBranches();
    }
    private void CreateBranches()
    {
        var treeArray = PollerTree.ReturnPolledObject();
        Instantiate(branchPrefab,new Vector3(0,0),Quaternion.identity,treeArray[0].transform);
        
        for (int i = 1; i < treeArray.Count; i++)
        {
            GameObject blockTree = treeArray[i].gameObject;
            
            int previosBranchValue = (int)treeArray[i - 1].transform.GetChild(0).position.x;
            int randomX = RandomBranchPos(previosBranchValue);

            GameObject branch = Instantiate(branchPrefab,new Vector3(randomX,blockTree.transform.position.y),Quaternion.identity,blockTree.transform);
            SetFlipSprite(branch,randomX);
        }
    }

    private void NewLastPositionBranch(List<GameObject> arrayTree)
    {
        GameObject lastBranch = arrayTree[arrayTree.Count - 1].transform.GetChild(0).gameObject;
        
        int previosLastBranch = (int)arrayTree[arrayTree.Count - 2].transform.GetChild(0).position.x;
        int randomX = RandomBranchPos(previosLastBranch);
        
        SetFlipSprite(lastBranch, randomX);
        lastBranch.transform.position = new Vector3(randomX,lastBranch.transform.position.y);
    }

    private void SetFlipSprite(GameObject currentBranch, int randomX)
    {
        currentBranch.GetComponent<SpriteRenderer>().flipX = randomX < 0 ? true : false;
    }

    private void ControlBranches(List<GameObject> arrayTree)
    {
        Transform lastBranch = arrayTree[arrayTree.Count - 1].transform.GetChild(0);
        Transform lastNextBranch = arrayTree[arrayTree.Count - 2].transform.GetChild(0);
        Transform lastNextNextBranch = arrayTree[arrayTree.Count - 3].transform.GetChild(0);
        Transform lastNextNextNextBranch = arrayTree[arrayTree.Count - 4].transform.GetChild(0);
        
        float lastBranchX = lastBranch.position.x;
        if (lastBranchX != lastNextBranch.position.x || lastBranchX != lastNextNextBranch.position.x)
        {
            return;
        }

        if (lastBranchX == 0)
        {
            while (lastBranchX == 0)
            {
                lastBranchX = Random.Range(-1, 2);
            }
            lastBranch.position = new Vector2(lastBranchX, lastBranch.position.y);
        }

        if (!lastNextBranch || !lastNextNextBranch || !lastNextNextNextBranch)
        {
            Debug.Log("null");
            return;
        }

        SetFlipSprite(lastBranch.gameObject,(int)lastBranch.transform.position.x);
        lastNextBranch.position = new Vector2(0,lastNextBranch.position.y);
        SetFlipSprite(lastNextNextBranch.gameObject, (int)(lastBranchX * -1));
        lastNextNextBranch.position =  new Vector2(lastBranchX * -1,lastNextNextBranch.position.y);
        lastNextNextNextBranch.position = new Vector2(0,lastNextNextNextBranch.position.y);
    }

    private int RandomBranchPos(int valuePreviosBranch)
    {
        int randomX = Random.Range(-1,2);
            
        while (valuePreviosBranch == (randomX * -1))
        {
            if (randomX == 0)
                break;
                
            randomX = Random.Range(-1, 1);
        }

        return randomX;
    }

    public void HitTree()
    {
        var array = PollerTree.ReturnPolledObject();
        GameObject firstBlock = array[0];
        
        PopFirstBlockTree(array[0]);
        PushLastBlockTree(firstBlock);

        NewLastPositionBranch(array);
        ControlBranches(array);

        DescresAllPosition(array);
    }

    private void DescresAllPosition(List<GameObject> arrayTree)
    {
        foreach (var blockArray in arrayTree)
        {
            blockArray.transform.position = new Vector2(blockArray.transform.position.x,blockArray.transform.position.y - 1);
        }
    }
    private void PopFirstBlockTree(GameObject firstBlock)
    {
        PollerTree.PoolObject(firstBlock);
        PollerTree.Remove(firstBlock);
    }

    private void PushLastBlockTree(GameObject firstBlock)
    {
        var arrayTree = PollerTree.ReturnPolledObject();
        
        int positionLastBlock = (int)arrayTree[arrayTree.Count - 1].transform.position.y + 1;
        firstBlock.transform.position = new Vector3(firstBlock.transform.position.x,positionLastBlock);
        firstBlock.SetActive(true);
        
        PollerTree.Add(firstBlock);
    }

    public void SetTree(GameObject treePrefab, GameObject branchPrefab)
    {
        this.treePrefab = treePrefab;
        this.branchPrefab = branchPrefab;
    }
}
