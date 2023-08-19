using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("Unique name for menu")]
    [Tooltip("Уникальный ключ для поиска меню")] public string menuName;
    //[Header("Camera for screen")]
    //[Tooltip("Камера, которая переключает на нужное меню")] public Camera menuCamera;
    [Header("Hide other UI?")]
    [Tooltip("На этом экране выключается \"OtherUI\"")] public bool hideOtherUI;
}
