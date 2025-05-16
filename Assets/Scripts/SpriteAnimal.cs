using System;
using UnityEngine;

public enum Animal
{
    Elephant,
    Pinguin,
    Bear
}

[Serializable]
public class SpriteAnimal
{
    public Animal animal;
    public Sprite sprite;
}
