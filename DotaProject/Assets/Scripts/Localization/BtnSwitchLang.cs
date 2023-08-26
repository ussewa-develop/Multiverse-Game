using UnityEngine;

// ������ ��� ������ ������������ �����
// ��� ������� ������ � ����� "ru-RU", "en-US" � �� ����� �� �������
public class BtnSwitchLang : MonoBehaviour
{
    [SerializeField]
    private LocalizationManager localizationManager;

    public void OnButtonClick()
    {
        localizationManager.CurrentLanguage = name;
    }
}
