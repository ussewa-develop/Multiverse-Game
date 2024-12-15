using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public string UnitName;
    public Cell OccupiedCell;
    public Faction Faction;
    [SerializeField] protected int baseMoveSpeed = 3;
    [SerializeField] public int hp;
    [SerializeField] public int maxHp = 10;
    [SerializeField] protected List<Cell> walkableCells;

    private void Start()
    {
        
    }
    public int MoveSpeed
    {
        get 
        { 
            return baseMoveSpeed; 
        }
    }
    

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
        UnitManager.Instance.SetSelectedHero(null);
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

    protected void ClearWalkableCellsList()
    {
        if (walkableCells == null)
        {
            return;
        }
        foreach (Cell cell in walkableCells)
        {
            cell.InRadius = false;
            cell.CanMoveVisualize(false);
        }
        walkableCells.Clear();
    }

    /*
     * ���� ������� ����������� ������� �� ��� �������� ������
     * � ��� ������� ������, �� ������� ����� ������
     * ��� ���� ������ �� ������� ������� �� �������� �������
     * � � FindPath �������� �������� �� ��������� ���������
     * � ���� Count < MoveSpeed, �� �������� �� ����� ���� �����
     * �� ��� ���� ��� ����� ��� �� ���������������
     * ���� �� ��������� ���������������, �� ������ MoveSpeed ������ ������ ������������
     * �� ����� �������� ���� CurrentMovePoints, ������� ������ �������� Count (CurrentMovePoints >= 0)
     * 
     * !!� � ����� ������ ����� �������� ������, ��� ������ �������� � ������� ����� �� ��������!! (��� ����� �������� ������ � HeroBase)
     */
    protected void CalculateWalkableCellsList()
    {
        ClearWalkableCellsList();
        int index = 0;
        for (int x = -MoveSpeed; x <= MoveSpeed; x++)
        {
            for (int y = -MoveSpeed; y <= MoveSpeed; y++)
            {
                Vector2 walkableCell = OccupiedCell.Coords.Pos + new Vector2(x, y);
                if (CellManager.Instance.GetWalkableCellAtPosition(walkableCell) != null)
                {
                    walkableCells.Add(CellManager.Instance.GetWalkableCellAtPosition(walkableCell));
                    walkableCells[index].InRadius = true;

                    index++;
                }
            }
        }

    }
}
