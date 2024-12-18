using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] List<Menu> screens;
    [SerializeField] List<GameObject> otherUI;
    [SerializeField] string _startMenu;

    private void Start()
    {
        OpenMenu(_startMenu);
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
