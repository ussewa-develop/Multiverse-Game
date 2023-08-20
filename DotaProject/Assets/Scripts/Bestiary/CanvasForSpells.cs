using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Tooltip("Скрипт для префаба канваса для нормального отображения панелек способностей")]
public class CanvasForSpells : MonoBehaviour
{
    // Скрипт для префаба канваса для нормального отображения панелек способностей

    private void Start()
    {
        EventManager.SwitchMenu += Destroy;
        gameObject.GetComponent<Canvas>().overrideSorting = true;
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        EventManager.SwitchMenu -= Destroy;
    }
}
