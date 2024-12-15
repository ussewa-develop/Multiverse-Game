using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;

    public BaseHero SelectedHero;

    private List<ScriptableUnit> _units;
        
    public delegate void EntitySelected(BaseUnit entity);
    public static event EntitySelected OnEntitySelected;
    

    private void Awake()
    {
        Instance = this;
        _units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
    }

    public void SpawnHeroes()
    {
        var heroCount = 2;
        for(int i = 0; i < heroCount; i++)
        {
            var randomPrefab = GetRandomUnit<BaseHero>(Faction.Hero);
            var spawnedHero = Instantiate(randomPrefab);
            var randomSpawnCell = CellManager.Instance.GetHeroSpawnCell();

            spawnedHero.Teleport(randomSpawnCell);
        }

        GameManager.Instance.ChangeState(GameState.SpawnEnemies);
    }

    public void SpawnEnemies()
    {
        var enemyCount = 1;
        for (int i = 0; i < enemyCount; i++)
        {
            var randomPrefab = GetRandomUnit<BaseEnemy>(Faction.Enemy);
            var spawnedEnemy = Instantiate(randomPrefab);
            var randomSpawnCell = CellManager.Instance.GetHeroSpawnCell();

            spawnedEnemy.Teleport(randomSpawnCell);
        }

        GameManager.Instance.ChangeState(GameState.HeroesTurn);
    }

    private T GetRandomUnit<T>(Faction faction) where T : BaseUnit//получаю первого рандомного юнита с выбраной "фракцией"
    {
        return (T)_units.Where(u=>u.Faction == faction).OrderBy(o => Random.value).First().unitPrefab;
    }

    public void SetSelectedEntity(BaseUnit unit)
    {
        OnEntitySelected?.Invoke(unit);
    }

    public void SetSelectedHero(BaseHero hero) 
    {
        SelectedHero = hero;
        SetSelectedEntity(hero);
        if(hero != null) hero.ShowCanMove();
    }

}
