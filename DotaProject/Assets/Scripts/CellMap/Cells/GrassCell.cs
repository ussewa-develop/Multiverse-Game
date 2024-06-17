using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassCell : Cell
{
    [SerializeField] protected Color _baseColor;
    [SerializeField] protected Color _offsetColor;
    public override void Init(int x, int y, ICoords coords)
    {
        base.Init(x, y, coords);
        var isOffset = (x+y)%2 == 1;
        if (isOffset)
        {
            ChangeColor(_offsetColor);
        }
        else
        {
            ChangeColor(_baseColor);
        }
    }
}
