using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerAttack : MonoBehaviour
{
    private GameTree gameTree;
    private PlayerPointsCollector pointsCollector;
    private PlayerTime playerTime;
    private Animator animator;
    private SoundsManager soundManager;
    
    
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
        soundManager = FindObjectOfType<SoundsManager>();
    }
    public void PressToHit(InputAction.CallbackContext hit)
    {
        if (hit.action.triggered && !GameManager.GameOver)
        {
            animator.Play("HitTree");
            gameTree.HitTree(hit);
            
            if(soundManager)
                soundManager.PlayDestroyTree();
            
            pointsCollector.UpdatePoints(pointForBlock);
            playerTime.UpdateTime(increaseTimer);
        }
    }
}
