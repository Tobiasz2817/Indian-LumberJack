using System;
using UnityEngine;
using TMPro;

public class PlayerPointsCollector : MonoBehaviour
{
    private TextMeshProUGUI pointsText;
    
    private int points = 0;

    private void Awake()
    {
        pointsText = GameObject.FindGameObjectWithTag("Points").GetComponent<TextMeshProUGUI>();
    }

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
