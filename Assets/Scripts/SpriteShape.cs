using System;
using UnityEngine;

public enum Shape
{
    Circle,
    Triangle,
    Square
}

[Serializable]
public class SpriteShape
{
    public Shape shape;
    public Sprite sprite;
}
