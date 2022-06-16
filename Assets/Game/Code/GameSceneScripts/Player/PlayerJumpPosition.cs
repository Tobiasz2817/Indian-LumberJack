using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJumpPosition : MonoBehaviour
{
    private SpriteRenderer playerSprite;
    
    private Vector2 leftJump;
    private Vector2 rightJump;

    private float sizeTree;
    void Awake()
    {
        var sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (var spriteRenderer in sprites)
        {
            if (spriteRenderer.gameObject.CompareTag("Character"))
            {
                playerSprite = spriteRenderer;
                break;
            }
        }
    }

    private void Start()
    {
        sizeTree = FindObjectOfType<GameTree>().transform.GetChild(0).localScale.x;
        
        leftJump = transform.position;
        rightJump = new Vector2(transform.position.x + sizeTree + 1, transform.position.y);
    }

    public void SwampPosition(InputAction.CallbackContext hit)
    {
        if (hit.action.triggered)
        {
            string currentHitName = hit.control.name;
            if (currentHitName == "a" || currentHitName == "leftArrow")
            {
                transform.position = leftJump;
                playerSprite.flipX = false;
            }
            else if (currentHitName == "d" || currentHitName == "rightArrow")
            {
                transform.position = rightJump;
                playerSprite.flipX = true;
            }
        }
    }
}
