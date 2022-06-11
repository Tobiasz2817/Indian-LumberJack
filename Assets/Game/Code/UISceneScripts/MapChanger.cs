using UnityEngine;
using UnityEngine.UI;

public class MapChanger : MonoBehaviour
{
    [SerializeField]
    private Sprite[] maps;

    private Image currentImage;
    private int currentIndex = 0;
    void Start()
    {
        currentImage = GetComponentInChildren<Image>();

        SetMap(currentIndex);
    }

    public void TurnRight()
    {
        currentIndex++;
        
        if (currentIndex > maps.Length - 1)
        {
            currentIndex = 0;
        }
        
        SetMap(currentIndex);
    }

    public void TurnLeft()
    {
        currentIndex--;
        
        if (currentIndex < 0)
        {
            currentIndex = maps.Length - 1;
        }
        
        SetMap(currentIndex);
    }

    public void SaveChanges()
    {
        GameManager.MapIndex = currentIndex;
    }

    private void SetMap(int index)
    {
        currentImage.sprite = maps[index];
    }
}
