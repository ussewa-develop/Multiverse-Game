using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



// Этот скрипт нужно добавить в эвент "OnClick" скрипта "Button"
public class SwitchButton : MonoBehaviour
{
    Hero hero;
    HeroScreen heroScreen;
    MenuManager menuManager;

    private void Awake()
    {
        hero = gameObject.GetComponent<Hero>();
        if (hero != null)
        {
            heroScreen = gameObject.transform.parent.GetComponent<HerosGatesScreen>().heroScreen;
        }
        menuManager = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>();
    }

    public void OnClick(string word) //выставляем этот метод в кнопке, если идет переход на любой другой экран в границах сцены
    {
        menuManager.OpenMenu(word);
        if (word == "heroScreen")
        {
            heroScreen.CreateHero(hero);
        }
        else
        {
            EventManager.OnSwitchingMenu();
        }
    }
   
}
