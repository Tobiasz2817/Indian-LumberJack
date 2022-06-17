using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool fpsCheck = false;
    public static bool playSounds = true;
    public static bool GameOver = false;
    public static int MapIndex = 0;
    public static Difficulty currentDiff { get; protected set; }
}
