using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HerosGatesScreen : MonoBehaviour
{
    static HerosGatesScreen instance;
    public HeroScreen heroScreen;
    public List<Hero> heroList;

    [SerializeField] Vector2 startCoordinate;
    [SerializeField] float offsetForIconsOnX = 147f;
    [SerializeField] float offsetForIconsOnY;

    private void Start()
    {
        AddHerosOnList();
        SetCoordinates();
    }

    private void AddHerosOnList()
    {
        for (int indexChild = 0; indexChild < gameObject.transform.childCount; indexChild++)
        {
            heroList.Add(gameObject.transform.GetChild(indexChild).GetComponent<Hero>());
        }
    }

    private void SetCoordinates()
    {
        for (int heroIndex = 0; heroIndex < heroList.Count; heroIndex++)
        {
            heroList[heroIndex].transform.localPosition = startCoordinate;
            heroList[heroIndex].transform.localPosition += new Vector3(offsetForIconsOnX * heroIndex, offsetForIconsOnY);
        }
    }
}
