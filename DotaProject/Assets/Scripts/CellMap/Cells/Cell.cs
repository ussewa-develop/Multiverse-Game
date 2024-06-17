using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Cell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string cellName;
    [SerializeField] GameObject _highlight;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private bool _isWalkable;

    public BaseUnit OccupiedUnit;
    public bool Walkable => _isWalkable && OccupiedUnit == null;
    public virtual void Init(int x, int y, ICoords coords)
    {
        Coords = coords;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        _highlight.SetActive(true);
        CanvasManager.Instance.ShowCellInfo(this);
        //ChangeColor(_hoverColor);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _highlight.SetActive(false);
        CanvasManager.Instance.ShowCellInfo(null);
        //ChangeColor(_standartColor);
    }

    public void OnMouseDown()
    {
        if (GameManager.Instance.gameState != GameState.HeroesTurn)
        {
            return;
        }
        if (OccupiedUnit != null)
        {
            if (OccupiedUnit.Faction == Faction.Hero)
            {
                UnitManager.Instance.SetSelectedHero((BaseHero)OccupiedUnit);
            }
            else
            {
                CanvasManager.Instance.ShowSelectedEntity(OccupiedUnit);
            }
        }
        else
        {
            if (UnitManager.Instance.SelectedHero != null)
            {
                UnitManager.Instance.SelectedHero.MoveOn(this);
                UnitManager.Instance.SelectedHero = null;
            }
            CanvasManager.Instance.ClearSelectedEntity();
        }
    }

    protected void ChangeColor(Color color)
    {
        _spriteRenderer.color = color;
    }

    #region Pathfinding
    public interface ICoords
    {
        public float GetDistance(ICoords other);
        public Vector2 Pos { get; set; }
    }
    public struct SquareCoords : ICoords
    {

        public float GetDistance(ICoords other)
        {
            var dist = new Vector2Int(Mathf.Abs((int)Pos.x - (int)other.Pos.x), Mathf.Abs((int)Pos.y - (int)other.Pos.y));

            var lowest = Mathf.Min(dist.x, dist.y);
            var highest = Mathf.Max(dist.x, dist.y);

            var horizontalMovesRequired = highest - lowest;

            return lowest * 14 + horizontalMovesRequired * 10;
        }

        public Vector2 Pos { get; set; }
    }

    public ICoords Coords;
    public List<Cell> Neighbors;
    //public List<Cell> Neighbors { get; protected set; }

    public Cell Connection { get; private set; }
    public float G { get; private set; }
    public float H { get; private set; }
    public float F => G + H;


    private static readonly List<Vector2> Dirs = new List<Vector2>() {
            new Vector2(0, 1), new Vector2(-1, 0), new Vector2(0, -1), new Vector2(1, 0),
            new Vector2(1, 1), new Vector2(1, -1), new Vector2(-1, -1), new Vector2(-1, 1)
    };

    public void CacheNeighbors()
    {
        Neighbors = new List<Cell>();

        foreach (var tile in Dirs.Select(dir => CellManager.Instance.GetCellAtPosition(Coords.Pos + dir)).Where(tile => tile != null))
        {
            Neighbors.Add(tile);
        }
    }
    public void SetConnection(Cell nodeBase)
    {
        Connection = nodeBase;
    }

    public void SetG(float g)
    {
        G = g;
    }

    public void SetH(float h)
    {
        H = h;
    }

    public float GetDistance(Cell other)
    {
        return Coords.GetDistance(other.Coords); // Helper to reduce noise in pathfinding
    }

 #endregion
}
