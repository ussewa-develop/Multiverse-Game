using System.Collections.Generic;
using UnityEngine;

public class GatesScreen : MonoBehaviour
{
    [Header("\t\tСкрипт для экрана с иконками")]
    [Space]
    public List<GameObject> childList;

    [SerializeField] Vector2 startCoordinate;
    [SerializeField] float offsetForIconsOnX = 147f;
    [SerializeField] float offsetForIconsOnY;

    protected void Start()
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

    private void SetCoordinates()//выставляет иконки по нужным координатам
    {
        for (int iconIndex = 0; iconIndex < childList.Count; iconIndex++)
        {
            childList[iconIndex].transform.localPosition = startCoordinate;
            childList[iconIndex].transform.localPosition += new Vector3(offsetForIconsOnX * iconIndex, offsetForIconsOnY);
        }
    }
}
