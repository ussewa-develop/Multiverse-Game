using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GatesScreen : MonoBehaviour
{
    public List<GameObject> childList;

    [SerializeField] Vector2 startCoordinate;
    [SerializeField] float offsetForIconsOnX = 147f;
    [SerializeField] float offsetForIconsOnY;

    private void Start()
    {
        AddGameObjectsOnList();
        SetCoordinates();
    }

    private void AddGameObjectsOnList()
    {
        for (int indexChild = 0; indexChild < gameObject.transform.childCount; indexChild++)
        {
            GameObject child = gameObject.transform.GetChild(indexChild).gameObject;
            if (!child.GetComponent<Canvas>())//на случай, если в дочерних обьектах есть канвас
            {
                childList.Add(child);
            }
            
        }
    }

    private void SetCoordinates()
    {
        for (int heroIndex = 0; heroIndex < childList.Count; heroIndex++)
        {
            childList[heroIndex].transform.localPosition = startCoordinate;
            childList[heroIndex].transform.localPosition += new Vector3(offsetForIconsOnX * heroIndex, offsetForIconsOnY);
        }
    }
}
