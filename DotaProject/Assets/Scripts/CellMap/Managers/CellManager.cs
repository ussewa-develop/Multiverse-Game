using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Cell;

public class CellManager : MonoBehaviour
{
    public static CellManager Instance;
    [SerializeField] private Vector2Int _gridSize;
    [SerializeField] private Cell _grassCell, _mountainCell;
    [SerializeField] private float _offset;
    [SerializeField] private Transform _parent;

    [SerializeField] Camera _mainCamera;

    Dictionary<Vector2, Cell> _cells;

    private void Awake()
    {
        Instance = this;
    }

    [ContextMenu("Clear Grid")]
    public void ClearGrid()
    {
        for(int i = 0; i < _parent.childCount; i++)
        {
            //удаляю обьекты
        }
    }

    [ContextMenu("Generate Grid")]
    public void GenerateGrid()
    {
        _cells = new Dictionary<Vector2, Cell>();
        //Vector2 cellSize = _grassCell.cellSize;
        for(int x = 0; x < _gridSize.x; x++)
        {
            for(int y = 0; y < _gridSize.y; y++)
            {
                var randomCell = Random.Range(0, 6) == 3 ? _mountainCell: _grassCell;

                //var position = new Vector2(x*(cellSize.x + _offset), y*(cellSize.y + _offset));
                var position = new Vector2(x + _offset, y + _offset); 
                var cell = Instantiate(randomCell, position, Quaternion.identity, _parent);
                cell.name = $"X: {x} Y: {y}";

                cell.Init(x,y, new SquareCoords { Pos = new Vector2 (x,y)});
                _cells[new Vector2(x, y)] = cell;
            }
        }

        //делим размер матрицы на 2, потом отнимаем половину от размера клетки
        float offsetX = (float)_gridSize.x / 2 - 0.5f;
        float offsetY = (float)_gridSize.y / 2 -0.5f;
        float offsetZ = -20f;
        //

        /*
        //делим размер матрицы на 2 и умножаем на коефицент размера клетки, потом отнимаем половину от размера клетки
        float offsetX = (float)_gridSize.x / 2 * cellSize.x - 0.5f * cellSize.x;
        float offsetY = (float)_gridSize.y / 2 * cellSize.y - 0.5f * cellSize.y;
        float offsetZ = -20f;
        //
        */
        _mainCamera.transform.position = new Vector3(offsetX, offsetY, offsetZ);//перемещаем камеру в центр матрицы
        CacheNeighbors(_cells);

    }
    private void CacheNeighbors(Dictionary<Vector2,Cell> cells)
    {
        foreach (var cell in cells)
        {
            cell.Value.CacheNeighbors();
        }

        GameManager.Instance.ChangeState(GameState.SpawnHeroes);
    }

    public Cell GetCellAtPosition(Vector2 position)//получаем клетку по позиции
    {
        if(_cells.TryGetValue(position, out var cell))
        {
            return cell;
        }
        return null;
    }

    public Cell GetWalkableCellAtPosition(Vector2 position)//модификация метода выше для получения клетки, по которой можно ходить
    {
        if(_cells.TryGetValue(position, out var cell))
        {
            if(!cell.Walkable) return null;
            return cell;
        }
        return null;
    }

    public Cell GetHeroSpawnCell()
    {
        return _cells.Where(t=>t.Key.x < _gridSize.x/2 && t.Value.Walkable).OrderBy(t=>Random.value).First().Value;
    }

    public Cell GetEnemySpawnCell()
    {
        return _cells.Where(t => t.Key.x > _gridSize.x / 2 && t.Value.Walkable).OrderBy(t => Random.value).First().Value;
    }
}
