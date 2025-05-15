using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Shape shape;

    private void Init(Shape shape)
    {
        this.shape = shape;
    }
}
