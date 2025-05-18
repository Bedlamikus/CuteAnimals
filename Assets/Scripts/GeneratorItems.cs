using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        GlobalEvents.RefreshItems.AddListener(RefreshItems);
        GlobalEvents.DestroyItem.AddListener(DestroyItem);
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
                item.Init(spriteAnimal, spriteColor, i);
                item.SetID(GetEqualsID(i, item));
                itemsList.Add(item);
                item.Hide();
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
                itemsList[i * columns + j].Show();
                yield return new WaitForSeconds(cooldownBeetwenLines / columns);
            }
            yield return new WaitForSeconds(cooldownBeetwenLines);
        }
    }

    private void HideItems()
    {
        for (int i = 0; i < itemsList.Count; i++)
        {
            itemsList[i].Hide();
        }
    }

    private void RefreshItems()
    {
        HideItems();
        ShowItems();
    }

    private void DestroyItem(Item item)
    {
        itemsList.Remove(item);
        item.Hide();

        if (itemsList.Count == 0)
        {
            GlobalEvents.GameWin.Invoke();
        }
    }

    private int GetEqualsID(int index, Item item)
    {
        foreach (Item item1 in itemsList)
        {
            if (item1 != null && 
                item1.GetShape == item.GetShape &&
                item1.GetColor.colorType == item.GetColor.colorType &&
                item1.GetAnimal.animal == item.GetAnimal.animal)
            {
                return item1.GetID;
            }
        }
        return index;
    }
}
