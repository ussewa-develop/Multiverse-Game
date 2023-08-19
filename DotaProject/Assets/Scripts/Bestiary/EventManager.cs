using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Entity;

public class EventManager : MonoBehaviour
{
    public static Action SwitchMenu;
    public static Action DestroyOtherSkills;

    public static int yForSummonsContentfield = -1500;//!!!!!эта и нижняя должны быть одинаковые!!!!!!
    public static int standartY = -1500;

    public static int deltaForY = 1450;

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
