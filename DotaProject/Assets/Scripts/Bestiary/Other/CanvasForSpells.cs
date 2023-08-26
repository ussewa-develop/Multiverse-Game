using UnityEngine;

[Tooltip("������ ��� ������� ������� ��� ����������� ����������� ������� ������������")]
public class CanvasForSpells : MonoBehaviour
{
    // ������ ��� ������� ������� ��� ����������� ����������� ������� ������������

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
