using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class HerosGatesScreen : GatesScreen
{
    [Header("Скрипт для экрана героя")]
    public HeroScreen heroScreen;
    [SerializeField] HeroGate heroIconPrefab;
    [SerializeField] bool checkOnInventory = false;


    protected new void Start()
    {
        LoadAllHerosSO();
        base.Start();

    }

    private void OnEnable()
    {
        if(checkOnInventory)
        CheckOnInventory();
    }

    private void LoadAllHerosSO()
    {
        var allSO = SODataLoader.LoadAllHerosSO();
        foreach (var hero in allSO)
        {
            HeroGate heroGate = Instantiate(heroIconPrefab,transform).GetComponent<HeroGate>();
            heroGate.Instantiate(hero);
        }
    }

    private void CheckOnInventory()
    {
        foreach (GameObject child in childList)
        {
            if(child.GetComponent<HeroGate>().hero.ConstLevel == 0)
            {
                child.GetComponent<UnityEngine.UI.Image>().color = new Color32(100,100,100,255);
            }
            else
            {
                child.GetComponent<UnityEngine.UI.Image>().color = new Color32(255, 255, 255, 255);
            }
        }
    }
}
