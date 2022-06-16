using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private LayerMask branchMask;
    
    private GameObject panelUI;

    private void Awake()
    {
        panelUI = GameObject.FindGameObjectWithTag("PanelOverUI");
        panelUI.SetActive(false);
    }

    public void CheckCollision(InputAction.CallbackContext hit)
    {
        if (hit.action.triggered)
        {
            var isSomething = Physics2D.Raycast(new Vector3(transform.position.x,transform.position.y - (transform.localScale.y / 2)), Vector2.up,1,branchMask);
            if (isSomething.collider != null)
            {
                GameOver();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Branch"))
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        GetComponent<EventInputController>().UnSubscriteEvents();

        panelUI.transform.GetChild(0).gameObject.SetActive(false);
        panelUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Game Over";
        panelUI.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "High score: " + GetHighestScore();
        panelUI.SetActive(true);
        GameManager.GameOver = true;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawRay(new Vector3(transform.position.x,transform.position.y - (transform.localScale.y / 2)),Vector3.up);
    }

    public int GetHighestScore()
    {
        var databaseInstaces = FindObjectOfType<Database>();
        int currentReachedScore = GetComponent<PlayerPointsCollector>().GetPoints();
        int currentScore = databaseInstaces.GetScore((int)GameManager.currentDiff);
        
        if (currentReachedScore > currentScore)
        {
            databaseInstaces.UpdateScore(currentReachedScore,(int)GameManager.currentDiff);

            return currentReachedScore;
        }

        return currentScore;
    }
}
