using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] List<Menu> screens;
    [SerializeField] List<GameObject> otherUI;
    private HeroScreen heroScreen;

    private void Start()
    {
        foreach (var screen in screens)
        {
            screen.gameObject.SetActive(false);
        }
        screens[0].gameObject.SetActive(true);
    }

    public void OpenMenu(string menuName)
    {
        foreach(Menu menu in screens)
        {
            if(menu.menuName == menuName)
            {
                menu.gameObject.SetActive(true);
                HideOtherUI(menu.hideOtherUI);
            }
            else
            {
                menu.gameObject.SetActive(false);
            }
        }
    }
    private void HideOtherUI(bool value)
    {
        foreach (GameObject uiElement in otherUI)
        {
            uiElement.gameObject.SetActive(!value);
        }
    }

}
