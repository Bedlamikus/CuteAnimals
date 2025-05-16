using UnityEngine;
using UnityEngine.Events;

public class GlobalEvents : MonoBehaviour
{
    public static UnityEvent<Item> SelectItem = new();
    public static UnityEvent<Item, Transform> AnimationMoveItem = new();

}
