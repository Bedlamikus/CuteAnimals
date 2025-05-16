using UnityEngine;

public class FreePoints : MonoBehaviour
{
    [SerializeField] private FreePoint[] points;
    [SerializeField] private Item[] items;

    private void Start()
    {
        GlobalEvents.SelectItem.AddListener(TryMoveItemToFreePoint);
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
}
