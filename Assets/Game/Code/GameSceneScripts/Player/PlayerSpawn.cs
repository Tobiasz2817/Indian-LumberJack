using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    void Start()
    {
        GameObject firstTree = FindObjectOfType<GameTree>().gameObject;
        if(firstTree)
            transform.position = new Vector3(firstTree.transform.GetChild(0).transform.position.x - 1,transform.position.y);
    }
}
