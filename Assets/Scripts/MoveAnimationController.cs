using System.Collections;
using UnityEngine;

public class MoveAnimationController : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Start()
    {
        GlobalEvents.AnimationMoveItem.AddListener(MoveItem);
    }

    private void MoveItem(Item item, Transform newPosition)
    {
        StartCoroutine(MoveToCoroutine(item, newPosition.position, Quaternion.identity, speed));
    }

    private IEnumerator MoveToCoroutine(Item item, Vector3 position, Quaternion rotation, float speed)
    {
        item.Disable();
        Vector3 startPosition = item.transform.position;
        float needTime = Vector3.Distance(startPosition, position) / speed;
        float timer = 0f;

        while (timer < needTime)
        {
            timer += Time.deltaTime;
            item.transform.position = Vector3.Lerp(startPosition, position, timer / needTime);
            yield return null;
        }

        item.transform.position = position;
        item.transform.rotation = rotation;
        GlobalEvents.MoveAnimationEnd.Invoke();
    }

}
