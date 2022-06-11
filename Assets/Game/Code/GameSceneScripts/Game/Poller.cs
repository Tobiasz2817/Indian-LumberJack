using System.Collections.Generic; 
using UnityEngine; 

public class Poller 
{
    private List<GameObject> myObjects = new List<GameObject>();
    public void CreatePoller(GameObject prefab)
    {
        myObjects.Add(prefab);
    }
    public GameObject GetObject()
    {
        for (int i = 0; i < myObjects.Count; i++)
        {
            if (!myObjects[i].activeInHierarchy)
            {
                return myObjects[i];
            }
        }

        return null;
    }
    public void PoolObject(GameObject poolObj)
    {
        if (myObjects.Contains(poolObj))
        {
            poolObj.SetActive(false);
        }
    }

    public List<GameObject> ReturnPolledObject()
    {
        return myObjects;
    }
    public void Add(GameObject addedObject)
    {
        myObjects.Add(addedObject);
    }
    public void Remove(GameObject removedObject)
    {
        myObjects.Remove(removedObject); 
    }
}