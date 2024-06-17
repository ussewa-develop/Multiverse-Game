using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public string UnitName;
    public Cell OccupiedCell;
    public Faction Faction;

    protected void SetOccupiedCell(Cell cell)
    {
        if (OccupiedCell != null)
        {
            OccupiedCell.OccupiedUnit = null;
        }
        cell.OccupiedUnit = this;
        OccupiedCell = cell;
    }

    public virtual void Teleport(Cell cell)
    {
        transform.position = cell.transform.position;
        SetOccupiedCell(cell);
    }

    public virtual void MoveOn(Cell cell)
    {
        var path = Pathfinding.FindPath(OccupiedCell, cell);
        StartCoroutine(Move(path));
        SetOccupiedCell(cell);
    }

    private IEnumerator Move(List<Cell> path)
    {
        path.Reverse();
        for(int i = 0; i < path.Count; i++)
        {
            transform.position = path[i].transform.position;
            yield return new WaitForSeconds(0.5f);
        }

    }
}
