using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("Unique name for menu")]
    [Tooltip("Уникальный ключ для поиска меню")] public string menuName;
    [Header("Hide other UI?")]
    [Tooltip("На этом экране выключается \"OtherUI\"")] public bool hideOtherUI;
}
