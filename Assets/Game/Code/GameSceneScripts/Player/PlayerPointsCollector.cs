using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPointsCollector : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI pointsText;
    
    private int points = 0;
    
    void Start()
    {
        pointsText.text = points.ToString();
    }
    public void UpdatePoints(int addPoint)
    {
        points += addPoint;
        pointsText.text = points.ToString();
    }

    public int GetPoints()
    {
        return points;
    }
}
