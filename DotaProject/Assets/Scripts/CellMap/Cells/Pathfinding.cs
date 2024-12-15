using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public static class Pathfinding
{
    public static List<Cell> FindPath(Cell startCell, Cell targetCell)
    {
        var toSearch = new List<Cell>() { startCell };
        var processed = new List<Cell>();

        while (toSearch.Any())
        {
            var current = toSearch[0];
            foreach (var t in toSearch)
            if (t.F < current.F || t.F == current.F && t.H < current.H)
            {
                    current = t;
            }
            processed.Add(current);
            toSearch.Remove(current);

            if (current == targetCell)
            {
                var currentPathCell = targetCell;
                var path = new List<Cell>();
                var count = 100;
                while (currentPathCell != startCell)
                {
                    path.Add(currentPathCell);
                    currentPathCell = currentPathCell.Connection;
                    count--;
                    if (count < 0) throw new Exception();
                }
                Debug.Log(path.Count);
                return path;
            }

            foreach (var neighbor in current.Neighbors.Where(t => t.Walkable && !processed.Contains(t)))
            {
                var inSearch = toSearch.Contains(neighbor);
                var costToNeighbor = current.G + current.GetDistance(neighbor);

                if (!inSearch || costToNeighbor < neighbor.G)
                {
                    neighbor.SetG(costToNeighbor);
                    neighbor.SetConnection(current);
                    if (!inSearch)
                    {
                        neighbor.SetH(neighbor.GetDistance(targetCell));
                        toSearch.Add(neighbor);
                    }
                }
            }
        }

        return null;
    }
}
