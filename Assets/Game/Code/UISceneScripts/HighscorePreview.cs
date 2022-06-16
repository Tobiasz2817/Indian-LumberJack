using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscorePreview : MonoBehaviour
{
    private Database database;
    private void Awake()
    {
        database = FindObjectOfType<Database>();
    }

    private void Start()
    {
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Easy: " + database.GetScore((int) Difficulty.Easy).ToString();
        transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "Medium: " + database.GetScore((int) Difficulty.Medium).ToString();
        transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Hard: " + database.GetScore((int) Difficulty.Hard).ToString();
    }
}
