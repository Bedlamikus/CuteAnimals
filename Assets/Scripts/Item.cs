using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Shape shape;
    [SerializeField] private Animal animal;
    [SerializeField] private ColorType colorType;

    [SerializeField] private SpriteRenderer spriteShape;
    [SerializeField] private SpriteRenderer spriteAnimal;
    [SerializeField] private Collider2D selfCollider;
    [SerializeField] private Rigidbody2D selfRigidbody;

    private void Start()
    {
        var poolAnimals = FindAnyObjectByType<PoolAnimals>();
        var poolColors = FindAnyObjectByType<PoolColors>();
        Init(poolAnimals, poolColors);
    }

    private void OnMouseUp()
    {
        GlobalEvents.SelectItem.Invoke(this);
    }

    private void Init(PoolAnimals poolAnimals, PoolColors poolColor)
    {
        spriteAnimal.sprite = poolAnimals.GetSpriteByAnimal(animal);
        spriteShape.color = poolColor.GetColorByColorType(colorType);
    }

    public void Disable()
    {
        selfCollider.enabled = false;
        selfRigidbody.isKinematic = true;
        selfRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
