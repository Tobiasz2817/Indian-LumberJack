using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] 
    private GameObject playerPrefab;

    [SerializeField] 
    private bool respawnAtStart = false;
    void Start()
    {
        if (respawnAtStart)
        {
            SpawnPlayer();
        }
    }

    private void SpawnPlayer()
    {
        GameObject firstTree = FindObjectOfType<GameTree>().gameObject;
        if(firstTree)
            Instantiate(playerPrefab, new Vector3(firstTree.transform.GetChild(0).transform.position.x - 1, transform.position.y), Quaternion.identity);
    }
    public void SpawnPlayer(Vector3 firstTree)
    {
        Instantiate(playerPrefab, new Vector3(firstTree.x - 1, transform.position.y), Quaternion.identity);
    }
}
