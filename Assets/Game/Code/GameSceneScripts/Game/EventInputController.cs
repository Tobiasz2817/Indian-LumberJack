using UnityEngine;
using UnityEngine.InputSystem;


public class EventInputController : MonoBehaviour
{
    private PlayerJumpPosition playerJump;
    private PlayerHealth playerHealth;
    private PlayerAttack playerAttack;

    private PlayerInput playerInput;
    void Awake()
    {
        playerJump = GetComponent<PlayerJumpPosition>();
        playerHealth = GetComponent<PlayerHealth>();
        playerAttack = GetComponent<PlayerAttack>();

        playerInput = GetComponent<PlayerInput>();
        
        SubscriteEvents();
    }

    public void SubscriteEvents()
    {
        var perf = playerInput.actions.FindAction("AttackTree");
        perf.performed += playerJump.SwampPosition;
        perf.performed += playerHealth.CheckCollision;
        perf.performed += playerAttack.PressToHit;
        
        var perfMultiply = playerInput.actions.FindAction("AttackTreeMultiply");
        perfMultiply.performed += playerJump.SwampPosition;
        perfMultiply.performed += playerHealth.CheckCollision;
        perfMultiply.performed += playerAttack.PressToHit;
    }

    public void UnSubscriteEvents()
    {
        var perf = playerInput.actions.FindAction("AttackTree");
        perf.performed -= playerJump.SwampPosition;
        perf.performed -= playerHealth.CheckCollision;
        perf.performed -= playerAttack.PressToHit;
        
        var perfMultiply = playerInput.actions.FindAction("AttackTreeMultiply");
        perfMultiply.performed -= playerJump.SwampPosition;
        perfMultiply.performed -= playerHealth.CheckCollision;
        perfMultiply.performed -= playerAttack.PressToHit;
    }
}
