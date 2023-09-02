using System;
using UnityEngine;

//������, ������� ������������ ������ (��� �� ������ ���� ��� �������������� ������ ����� � ���������

public class EventController : MonoBehaviour
{
    public static Action SwitchMenu; //�����, ������� �����������, ����� �������� ����
    public static Action DestroyOtherSkills; //�����, ������� �����������, ����� ����� ������� ������ ������ � ������ �����

    public static int yForSummonsContentfield = -1800;//  }-\
    //                                                      | - ������ ���� ���������� 
    public static int standartY = -1800;//                }-/

    public static int deltaForY = 1600; // ������� ��� Y

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
