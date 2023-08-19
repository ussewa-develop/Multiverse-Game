using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("Unique name for menu")]
    [Tooltip("���������� ���� ��� ������ ����")] public string menuName;
    //[Header("Camera for screen")]
    //[Tooltip("������, ������� ����������� �� ������ ����")] public Camera menuCamera;
    [Header("Hide other UI?")]
    [Tooltip("�� ���� ������ ����������� \"OtherUI\"")] public bool hideOtherUI;
}
