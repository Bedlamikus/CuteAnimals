using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Shape shape;
    [SerializeField] private SpriteRenderer spriteShape;
    [SerializeField] private SpriteRenderer spriteAnimal;
    [SerializeField] private SpriteRenderer spriteBackGround;
    [SerializeField] private Collider2D selfCollider;
    [SerializeField] private Rigidbody2D selfRigidbody;

    public SpriteColor GetColor => color;
    public SpriteAnimal GetAnimal => animal;
    public Shape GetShape => shape;

    private int ID = 0;
    private SpriteAnimal animal;
    private SpriteColor color;

    private void OnMouseUp()
    {
        GlobalEvents.SelectItem.Invoke(this);
    }

    public void Init(SpriteAnimal animal, SpriteColor color, int ID)
    {
        this.animal = animal;
        this.color = color;
        this.ID = ID;
        spriteAnimal.sprite = animal.sprite;
        spriteShape.color = color.color;
    }

    public int GetID => ID;
    
    public void SetID(int ID)
    {
        this.ID = ID;
    }

    public void Hide()
    {
        Disable();
        spriteShape.enabled = false;
        spriteAnimal.enabled = false;
        spriteBackGround.enabled = false;
    }

    public void Show()
    {
        Enable();
        spriteShape.enabled = true;
        spriteAnimal.enabled = true;
        spriteBackGround.enabled = true;
    }

    public void Disable()
    {
        selfCollider.enabled = false;
        selfRigidbody.isKinematic = true;
        selfRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void Enable()
    {
        selfCollider.enabled = true;
        selfRigidbody.isKinematic = false;
        selfRigidbody.constraints = RigidbodyConstraints2D.None;
    }
}
