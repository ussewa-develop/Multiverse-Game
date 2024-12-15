using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum ShowCellMode //мод показывания клеток
{
    InMoveSpeedRadius = 0, //в радиусе ходьбы, учитывая IsWalkable
    IgnoreWalkable = 1, //в радиусе ходьбы, не учитывая IsWalkable
}

public class BaseHero : BaseUnit
{
    private void Start()
    {
        UnitManager.OnEntitySelected += OnEntitySelected;
    }

    private void OnDestroy()
    {
        UnitManager.OnEntitySelected -= OnEntitySelected;
    }

    public void OnEntitySelected(BaseUnit unit)
    {
        if (unit != this)
        {
            ClearWalkableCellsList();
            return;
        }
    }

    public void ShowCanMove()
    {
        CalculateWalkableCellsList();
        /*
        foreach (var tile in Dirs.Select(dir => CellManager.Instance.GetCellAtPosition(OccupiedCell.Coords.Pos + dir)).Where(tile => tile != null))
        {
            Debug.Log(OccupiedCell.Coords.Pos);
            walkableCells.Add(tile);
        }
        */
        foreach (var cell in walkableCells)
        {
            cell.CanMoveVisualize(true);
        }
    }
}
