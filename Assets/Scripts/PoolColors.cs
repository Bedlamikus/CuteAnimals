using UnityEngine;

public class PoolColors : MonoBehaviour
{
    [SerializeField] private SpriteColor[] colors;

    public Color GetColorByColorType(ColorType color)
    {
        foreach (var someColor in colors)
        {
            if (someColor.colorType == color)
            {
                return someColor.color;
            }
        }
        return Color.black;
    }
}
