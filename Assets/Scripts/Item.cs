using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteShape;
    [SerializeField] private SpriteRenderer spriteAnimal;
    [SerializeField] private SpriteRenderer spriteBackGround;
    [SerializeField] private Collider2D selfCollider;
    [SerializeField] private Rigidbody2D selfRigidbody;

    private int ID = 0;

    private void OnMouseUp()
    {
        GlobalEvents.SelectItem.Invoke(this);
    }

    public void Init(Sprite animal, Color color, int ID)
    {
        spriteAnimal.sprite = animal;
        spriteShape.color = color;
        this.ID = ID;
    }

    public int GetID => ID;

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
