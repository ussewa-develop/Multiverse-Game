using UnityEngine;

[Tooltip("Скрипт для префаба канваса для нормального отображения панелек способностей")]
public class CanvasForSpells : MonoBehaviour
{
    // Скрипт для префаба канваса для нормального отображения панелек способностей

    private void Start()
    {
        EventController.SwitchMenu += Destroy;
        gameObject.GetComponent<Canvas>().overrideSorting = true;
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        EventController.SwitchMenu -= Destroy;
    }
}
