using UnityEngine;

// ���� ������ ����� �������� � ����� "OnClick" ������� "Button"

public class SwitchButton : MonoBehaviour
{
    HeroGate heroGate;
    HeroScreen heroScreen;
    MenuManager menuManager;

    private void Awake()
    {
        heroGate = gameObject.GetComponent<HeroGate>();
        if (heroGate != null)
        {
            heroScreen = gameObject.transform.parent.GetComponent<HerosGatesScreen>().heroScreen;
        }
        menuManager = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>();
    }

    public void OnClick(string word) //���������� ���� ����� � ������, ���� ���� ������� �� ����� ������ ����� � �������� �����
    {
        menuManager.OpenMenu(word);
        if (word == "heroScreen")
        {
            heroScreen.CreateHero(heroGate.hero);
        }
        else
        {
            EventController.OnSwitchingMenu();
        }
    }
   
}
