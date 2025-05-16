using System;
using UnityEngine;

public enum Shape
{
    Circle,
    Triangle,
    Square,
    Hexagon
}

[Serializable]
public class SpriteShape
{
    public Shape shape;
    public Sprite sprite;
}
