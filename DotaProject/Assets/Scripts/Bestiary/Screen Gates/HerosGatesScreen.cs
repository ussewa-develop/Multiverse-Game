using UnityEngine;

public class HerosGatesScreen : GatesScreen
{
    [Header("������ ��� ������ �����")]
    public HeroScreen heroScreen;
    [SerializeField] HeroGate heroIconPrefab;


    protected new void Start()
    {
        LoadAllHerosSO();
        base.Start();
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
}
