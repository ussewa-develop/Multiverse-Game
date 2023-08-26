using System;
using UnityEngine;

//������, ������� ������������ ������ (��� �� ������ ���� ��� �������������� ������ ����� � ���������

public class EventController : MonoBehaviour
{
    public static Action SwitchMenu; //�����, ������� �����������, ����� �������� ����
    public static Action DestroyOtherSkills; //�����, ������� �����������, ����� ����� ������� ������ ������ � ������ �����

    public static int yForSummonsContentfield = -1500;//  }-\
    //                                                      | - ������ ���� ���������� 
    public static int standartY = -1500;//                }-/

    public static int deltaForY = 1450; // ������� ��� Y

    public static void SetStandartY()
    {
        yForSummonsContentfield = standartY;
    }


    public static void OnSwitchingMenu()
    {
        SwitchMenu?.Invoke();
    }

    public static void OnDestroyOtherSkills()
    {
        DestroyOtherSkills?.Invoke();
    }
}
