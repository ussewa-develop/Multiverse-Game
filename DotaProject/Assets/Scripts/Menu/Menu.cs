using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("Unique name for menu")]
    [Tooltip("���������� ���� ��� ������ ����")] public string menuName;
    [Header("Hide other UI?")]
    [Tooltip("�� ���� ������ ����������� \"OtherUI\"")] public bool hideOtherUI;
}
