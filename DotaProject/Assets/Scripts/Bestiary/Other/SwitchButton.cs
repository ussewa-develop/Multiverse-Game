using UnityEngine;

// Этот скрипт нужно добавить в эвент "OnClick" скрипта "Button"

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

    public void OnClick(string word) //выставляем этот метод в кнопке, если идет переход на любой другой экран в границах сцены
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
