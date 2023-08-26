using System;
using UnityEngine;

//скрипт, который обрабатывает эвенты (так же хранит поля для форматирования экрана героя с суммонами

public class EventController : MonoBehaviour
{
    public static Action SwitchMenu; //эвент, который срабатывает, когда меняется окно
    public static Action DestroyOtherSkills; //эвент, который срабатывает, когда нужно удалить другие скиллы в экране героя

    public static int yForSummonsContentfield = -1500;//  }-\
    //                                                      | - должны быть одинаковые 
    public static int standartY = -1500;//                }-/

    public static int deltaForY = 1450; // разница для Y

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
