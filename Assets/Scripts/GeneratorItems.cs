using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class GeneratorItems : MonoBehaviour
{
    [SerializeField] private PoolAnimals animalsPool;
    [SerializeField] private PoolColors colorsPool;
    [SerializeField] private Item[] itemPrefabs;

    [SerializeField] private int randomizeItemCount = 14;
    [SerializeField] private int columns = 6;
    [SerializeField] private float margin = 0.75f;
    
    [SerializeField] private float cooldownBeetwenLines = 0.3f;

    private List<Item> itemsList = new();

    private void Start()
    {
        GenerateItems();
        RandomizeItems();
        ShowItems();
    }

    private void GenerateItems()
    {
        for (int i = 0; i < randomizeItemCount; i++)
        {
            int itemIndex = Random.Range(0, itemPrefabs.Length);
            SpriteColor spriteColor = colorsPool.GetRandomColor();
            SpriteAnimal spriteAnimal = animalsPool.GetRandomAnimal();

            for (int j = 0; j < 3; j++)
            {
                Item item = Instantiate(itemPrefabs[itemIndex]);
                item.Init(spriteAnimal.sprite, spriteColor.color, i);
                itemsList.Add(item);
                item.gameObject.SetActive(false);
            }
        }
    }

    private void RandomizeItems()
    {
        var newList = new List<Item>();
        while (itemsList.Count > 0)
        {
            int index = Random.Range(0, itemsList.Count);
            Item item = itemsList[index];
            newList.Add(item);
            itemsList.RemoveAt(index);
        }
        itemsList = newList;
    }

    private void ShowItems()
    {
        StartCoroutine(AnimationShowItems());
    }

    private IEnumerator AnimationShowItems()
    {
        for (int i = 0; i < itemsList.Count / columns; i++) 
        {
            for (int j = 0; j < columns; j++)
            {
                itemsList[i * columns + j].transform.position = transform.position + Vector3.right * margin * j;
                itemsList[i * columns + j].gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(cooldownBeetwenLines);
        }
    }
}
