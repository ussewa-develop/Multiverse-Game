using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButton : MonoBehaviour
{
    /*
    MenuManager menuManager;
    public string menuName;
    Hero hero;

    private void Awake()
    {
        menuManager = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>();
        if(gameObject.TryGetComponent(out Hero hero))
        {
            menuName = "heroScreen";
            hero = gameObject.GetComponent<Hero>();
            Debug.Log(hero.GetName());
        }
    }

    public void ChangeMenu()
    {
        if(menuName == "heroScreen")
        {
            menuManager.OpenMenu(menuName, hero);
        }
        else
        {
            menuManager.OpenMenu(menuName);
        }
       
    }
    */    
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

    public void ClickOnHeroScreen()
    {
        if(hero!=null)
        {
            SwitchToHeroScreen();
        }
        else
        {
            SwitchToHeroIcons();
        }
    }

    public void OnClick(string word)
    {
        menuManager.OpenMenu(word);
    }

    private void SwitchToHeroScreen()
    {
        heroScreen.CreateHero(hero);
        menuManager.OpenMenu("heroScreen");
    }

    private void SwitchToHeroIcons()
    {
        menuManager.OpenMenu("heroGates");
        EventManager.OnSwitchingMenu();
    }
    
}
