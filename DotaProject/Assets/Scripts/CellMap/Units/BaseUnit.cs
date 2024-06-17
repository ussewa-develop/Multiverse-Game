using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public string UnitName;
    public Cell OccupiedCell;
    public Faction Faction;

    public virtual void Teleport(Cell cell)
    {
        if (OccupiedCell != null)
        {
            OccupiedCell.OccupiedUnit = null;
        }
        transform.position = cell.transform.position;
        cell.OccupiedUnit = this;
        OccupiedCell = cell;
    }

    public virtual void MoveOn(Cell cell)
    {

    }
}
