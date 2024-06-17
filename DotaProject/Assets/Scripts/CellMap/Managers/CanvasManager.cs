using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;

    public SelectedEntityUI selectedEntityUI;
    public SelectedCellUI selectedCellUI;
    private void Awake()
    {
        Instance = this;
    }

    public void ShowCellInfo(Cell cell)
    {
        if(cell == null)
        {
            selectedCellUI.gameObject.SetActive(false);
            selectedCellUI.selectedEntityUI.gameObject.SetActive(false);
            return;
        }

        selectedCellUI.cellInfoText.text = cell.cellName;
        selectedCellUI.gameObject.SetActive(true);

        if (cell.OccupiedUnit != null)
        {
            selectedCellUI.selectedEntityUI.entityNameText.text = cell.OccupiedUnit.UnitName;
            selectedCellUI.selectedEntityUI.gameObject.SetActive(true);
        }
        else
        {
            selectedCellUI.selectedEntityUI.gameObject.SetActive(false);
        }
    }

    public void ShowSelectedEntity(BaseUnit unit)
    {
        if(unit == null)
        {
            selectedEntityUI.gameObject.SetActive(false);
            return;
        }
        selectedEntityUI.entityNameText.text = unit.name;
        selectedEntityUI.gameObject.SetActive(true);
    }

    public void ClearSelectedEntity()
    {
        ShowSelectedEntity(null);
    }
}
