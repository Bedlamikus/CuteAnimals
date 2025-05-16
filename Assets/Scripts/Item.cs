using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Shape shape;
    [SerializeField] private Animal animal;
    [SerializeField] private ColorType colorType;

    [SerializeField] private SpriteRenderer spriteShape;
    [SerializeField] private SpriteRenderer spriteAnimal;

    private void Start()
    {
        var poolAnimals = FindAnyObjectByType<PoolAnimals>();
        var poolColors = FindAnyObjectByType<PoolColors>();
        Init(poolAnimals, poolColors);
    }

    public void Init(PoolAnimals poolAnimals, PoolColors poolColor)
    {
        spriteAnimal.sprite = poolAnimals.GetSpriteByAnimal(animal);
        spriteShape.color = poolColor.GetColorByColorType(colorType);
    }
}
