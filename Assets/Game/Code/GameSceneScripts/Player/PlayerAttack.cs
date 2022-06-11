using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerAttack : MonoBehaviour
{
    private GameTree gameTree;
    private PlayerPointsCollector pointsCollector;
    private PlayerTime playerTime;
    private Animator animator;

    [SerializeField] 
    private int pointForBlock;
    [SerializeField] 
    private float increaseTimer;
    private void Awake()
    {
        gameTree = FindObjectOfType<GameTree>();
        playerTime = FindObjectOfType<PlayerTime>();
        animator = GetComponentInChildren<Animator>();
        pointsCollector = GetComponent<PlayerPointsCollector>();
    }
    public void PressToHit(InputAction.CallbackContext hit)
    {
        if (hit.action.triggered && !GameManager.GameOver)
        {
            animator.Play("HitTree");
            gameTree.HitTree();
            
            
            pointsCollector.UpdatePoints(pointForBlock);
            playerTime.UpdateTime(increaseTimer);
        }
    }
}
