using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GatesScreen : MonoBehaviour
{
    [Header("\t\t������ ��� ������ � ��������")]
    [Space]
    public List<GameObject> childList;

    [SerializeField] Vector2 startCoordinate;
    [SerializeField] float offsetForIconsOnX = 147f;
    [SerializeField] float offsetForIconsOnY;
    [SerializeField] float maxItemsOnX = 11;

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
            if (!child.GetComponent<Canvas>() || !child.GetComponent<ScrollRect>())//�� ������, ���� � �������� �������� ���� ������
            {
                childList.Add(child);
            }
            
        }
    }

    
    private void SetCoordinates()//���������� ������ �� ������ �����������
    {
        int counterX = 0;
        int counterY = 0;
        for (int iconIndex = 0; iconIndex < childList.Count; iconIndex++)
        {
            if (counterX == maxItemsOnX)
            {
                counterX = 0;
                counterY -= 100;
            }
            offsetForIconsOnX = childList[iconIndex].GetComponent<Image>().rectTransform.rect.width;
            childList[iconIndex].transform.localPosition = startCoordinate;
            childList[iconIndex].transform.localPosition += new Vector3(offsetForIconsOnX * counterX, offsetForIconsOnY + counterY);
            counterX++;
        }
    }
    

}
