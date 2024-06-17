using System.Collections;
using System.Collections.Generic;
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
    public virtual void Init(int x, int y)
    {
       
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
        if(GameManager.Instance.gameState != GameState.HeroesTurn)
        {
            return;
        }
        if(OccupiedUnit != null)
        {
            if(OccupiedUnit.Faction == Faction.Hero)
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
               UnitManager.Instance.SelectedHero.Teleport(this);
               UnitManager.Instance.SelectedHero = null;
            }
            CanvasManager.Instance.ClearSelectedEntity();
        }
    }

    protected void ChangeColor(Color color)
    {
        _spriteRenderer.color = color;
    }
}
