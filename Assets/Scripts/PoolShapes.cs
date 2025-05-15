using UnityEngine;

public class PoolShapes : MonoBehaviour
{
    [SerializeField] private SpriteShape[] shapes;

    public Sprite GetSpriteByShape(Shape shape)
    {
        foreach (var someShape in  shapes)
        {
            if (someShape.shape == shape)
            {
                return someShape.sprite;
            }
        }
        return null;
    }
}