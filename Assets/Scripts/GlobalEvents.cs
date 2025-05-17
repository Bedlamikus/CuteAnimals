using UnityEngine;
using UnityEngine.Events;

public class GlobalEvents : MonoBehaviour
{
    public static UnityEvent<Item> SelectItem = new();
    public static UnityEvent<Item, Transform> AnimationMoveItem = new();
    public static UnityEvent RefreshItems = new();
    public static UnityEvent<Item> DestroyItem = new();
    public static UnityEvent MoveAnimationEnd = new();
    public static UnityEvent<Vector3> PlayParticles = new();

    public static UnityEvent GameOver = new();
    public static UnityEvent RestartGame = new();
    public static UnityEvent GameWin = new();
}
