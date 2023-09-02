using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortLayerForCanvas : MonoBehaviour
{
    [SerializeField] int sortLayer;

    private void Start()
    {
        GetComponent<Canvas>().sortingOrder = sortLayer;
    }
}
