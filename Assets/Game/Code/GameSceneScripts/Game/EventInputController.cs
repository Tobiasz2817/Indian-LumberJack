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
        SubscribeAction("AttackTree");
        SubscribeAction("AttackTreeMultiply");
    }

    public void UnSubscriteEvents()
    {
        UnSubscribeAction("AttackTree");
        UnSubscribeAction("AttackTreeMultiply");
    }
    public void SubscribeAction(string action)
    {
        var perf = playerInput.actions.FindAction(action);
        perf.performed += playerJump.SwampPosition;
        perf.performed += playerHealth.CheckCollision;
        perf.performed += playerAttack.PressToHit;
    }
    public void UnSubscribeAction(string action)
    {
        var perf = playerInput.actions.FindAction(action);
        perf.performed -= playerJump.SwampPosition;
        perf.performed -= playerHealth.CheckCollision;
        perf.performed -= playerAttack.PressToHit;
    }
}
