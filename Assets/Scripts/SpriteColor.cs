using System;
using UnityEngine;

public enum ColorType
{
    Red,
    Blue,
    Green,
    Yellow,
    LightBlue,
    LightGreen
}

[Serializable]
public class SpriteColor
{
    public ColorType colorType;
    public Color color;
}
