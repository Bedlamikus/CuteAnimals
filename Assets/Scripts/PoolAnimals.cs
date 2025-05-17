using UnityEngine;

public class PoolAnimals : MonoBehaviour
{
    [SerializeField] private SpriteAnimal[] animals;

    public Sprite GetSpriteByAnimal(Animal animal)
    {
        foreach (var someAnimal in animals)
        {
            if (someAnimal.animal == animal)
            {
                return someAnimal.sprite;
            }
        }
        return null;
    }

    public SpriteAnimal GetRandomAnimal()
    {
        return animals[Random.Range(0, animals.Length)];
    }
}
