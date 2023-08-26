using UnityEngine;

// Скрипт для кнопки переключения языка
// Имя обьекта делать в стиле "ru-RU", "en-US" и тд чтобы не путатся
public class BtnSwitchLang : MonoBehaviour
{
    [SerializeField]
    private LocalizationManager localizationManager;

    public void OnButtonClick()
    {
        localizationManager.CurrentLanguage = name;
    }
}
