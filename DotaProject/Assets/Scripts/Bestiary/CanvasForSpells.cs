using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Tooltip("������ ��� ������� ������� ��� ����������� ����������� ������� ������������")]
public class CanvasForSpells : MonoBehaviour
{
    // ������ ��� ������� ������� ��� ����������� ����������� ������� ������������

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
