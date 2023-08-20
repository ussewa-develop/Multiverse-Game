using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



// ���� ������ ����� �������� � ����� "OnClick" ������� "Button"
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

    public void ClickOnHeroScreen() //���������� ���� ����� � ������, ���� ���� ������� �� ����� ����� ��� � ���� (�� ����� ������ ������)
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

    public void OnClick(string word) //���������� ���� ����� � ������, ���� ���� ������� �� ����� ������ ����� � �������� �����
    {
        menuManager.OpenMenu(word);
        EventManager.OnSwitchingMenu();
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
