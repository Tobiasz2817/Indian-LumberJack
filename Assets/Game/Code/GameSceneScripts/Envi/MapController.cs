using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField]
    private Map[] avaliableMaps;

    private int indexCurrentMap;
    public void Awake()
    {
        indexCurrentMap = GameManager.MapIndex;
        
        CreateEnviroment();
    }

    private void CreateEnviroment()
    {
        SetMap(avaliableMaps[indexCurrentMap].MapObjects);
        SetTree(avaliableMaps[indexCurrentMap].treePrefab,avaliableMaps[indexCurrentMap].branchPrefab);
        MapLoaded();
    }
    private void SetMap(MapObject[] arrayMapObjects)
    {
        MapObject currentObject;
        for (int i = 0; i < arrayMapObjects.Length; i++)
        {
            currentObject = arrayMapObjects[i];

            GameObject newMapObject = Instantiate(new GameObject(currentObject.nameElement), transform);
            SetTransform(newMapObject.transform,currentObject.position, currentObject.rotation,currentObject.scale);

            SetRenderer(newMapObject,currentObject);
        }
        
    }
    private void SetTree(TreeObject branchPrefab, TreeObject treePrefab)
    {
        GameObject branchPref = branchPrefab.prefabGameObject;
        SetTransform(branchPref.transform,branchPrefab.position,branchPrefab.rotation,branchPrefab.scale);
        SetRenderer(branchPref,branchPrefab);

        GameObject treePref = treePrefab.prefabGameObject;
        SetTransform(treePref.transform,treePrefab.position,treePrefab.rotation,treePrefab.scale);
        SetRenderer(treePref,treePrefab);
        
        FindObjectOfType<GameTree>().SetTree(branchPrefab.prefabGameObject,treePrefab.prefabGameObject);
    }
    private void SetTransform(Transform newTransform,Vector3 position, Quaternion rotation, Vector3 scale)
    {
        newTransform.position = position;
        newTransform.rotation = rotation;
        newTransform.localScale = scale;
    }

    private void SetRenderer(GameObject prefab,MapObject mapObject)
    {
        SpriteRenderer newRenderer; 
        prefab.TryGetComponent<SpriteRenderer>(out newRenderer);
        if(!newRenderer)
            newRenderer = prefab.AddComponent<SpriteRenderer>();
        
        newRenderer.sprite = mapObject.mapSprite;
        newRenderer.flipX = mapObject.flipSpriteX;
        newRenderer.sortingOrder = mapObject.orderSprite;
    }
    private void MapLoaded()
    {
        PlayerTime myTime = FindObjectOfType<PlayerTime>();
        if (!myTime)
        {
            FindObjectOfType<PlayerHealth>().GameOver();
            Debug.LogError("Something is wrong Game Crash");
            return;
        }
        
        myTime.enabled = true;
    }
}
