using UnityEngine;

public class FreePoints : MonoBehaviour
{
    [SerializeField] private FreePoint[] points;
    [SerializeField] private Item[] items;

    private void Start()
    {
        GlobalEvents.SelectItem.AddListener(TryMoveItemToFreePoint);
        GlobalEvents.MoveAnimationEnd.AddListener(CheckEqualsItems);
    }

    private void TryMoveItemToFreePoint(Item item)
    {
        int index = PutItemToItems(item);

        if (index == -1) return;

        GlobalEvents.AnimationMoveItem.Invoke(item, points[index].transform);
    }

    private int PutItemToItems(Item item)
    {
        int freePointIndex = GetFreePoint();

        if (freePointIndex == -1) return -1;

        items[freePointIndex] = item;
        return freePointIndex;
    }

    private int GetFreePoint()
    {
        for (int i = 0; i < points.Length; i++)
        {
            if (points[i].SetBusy() == true)
                return i;
        }

        return -1;
    }

    private void CheckEqualsItems()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                int id = items[i].GetID;
                int count = 1;
                for (int j = i + 1; j < points.Length; j ++)
                {
                    if (items[j] != null && items[j].GetID == id)
                    {
                        count++;
                    }
                }
                if (count >= 3)
                {
                    for (int j = 0; j < items.Length; j++)
                    {
                        if (items[j] != null && items[j].GetID == id && count > 0)
                        {
                            count--;
                            GlobalEvents.DestroyItem.Invoke(CleanItem(j));
                            points[j].SetFree();
                            GlobalEvents.PlayParticles.Invoke(points[j].transform.position);
                        }
                    }
                }
            }
        }
    }

    private Item CleanItem(int index)
    {
        Item item = items[index];
        items[index] = null;
        return item;
    }
}
