using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MapController", order = 1)]
public class Map : ScriptableObject
{
    public MapObject[] MapObjects;

    public TreeObject branchPrefab;
    public TreeObject treePrefab;
}
[Serializable]
public class MapObject
{
    public string nameElement;
    
    [Header("Transform")]
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;

    [Header("Sprite")]
    public Sprite mapSprite;
    public bool flipSpriteX = false;
    public int orderSprite;
}

[Serializable]
public class TreeObject : MapObject
{
    public GameObject prefabGameObject;
}