using TMPro;
using UnityEngine;

public enum Difficulty{
    Easy = 10,
    Medium = 13,
    Hard = 16
}
public class DifficultySelection : GameManager
{

    [SerializeField] 
    private TextMeshProUGUI diffTextSelection;

    private Difficulty diff;
    private int differenceBetweenEnums;

    void Start()
    {
        differenceBetweenEnums = (Difficulty.Hard - Difficulty.Easy) / 2;
        
        diff = Difficulty.Easy;
        SetChanges();
    }
    public void RightSwitch()
    {
        diff+=differenceBetweenEnums;
        
        if (diff > Difficulty.Hard)
            diff = Difficulty.Easy;
        
        diffTextSelection.text = diff.ToString();
    }
    public void LeftSwitch()
    {
        diff-=differenceBetweenEnums;
        
        if (diff < Difficulty.Easy)
            diff = Difficulty.Hard;
        
        diffTextSelection.text = diff.ToString();
    }
    public void SetChanges()
    {
        GameManager.currentDiff = diff;
    }
}
