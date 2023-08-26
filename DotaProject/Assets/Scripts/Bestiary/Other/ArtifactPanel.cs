using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArtifactPanel : MonoBehaviour
{
    public TextMeshProUGUI itemNameText;
    public Image itemIcon;
    public TextMeshProUGUI itemTypeText;
    public TextMeshProUGUI itemDescText;
    public GameObject downStats;
    public GameObject background;
    public SkillPanel skillPanelPrefab;
    public Canvas canvasPrefab;
    public RectTransform contentField;
    public Button exitButton;

    public static Action SafePanelEvent;

    private void Start()
    {
        EventController.SwitchMenu += Destroy;
        SafePanelEvent += EnableExitButton;
    }

    private void OnDestroy()
    {
        EventController.SwitchMenu -= Destroy;
        SafePanelEvent -= EnableExitButton;
        
    }

    public void EnableExitButton()
    {
        exitButton.gameObject.SetActive(!exitButton.gameObject.activeSelf);
    }

    public static void OnChangeSafePanel()
    {
        SafePanelEvent?.Invoke();
    }

    public void Destroy()
    {
        ArtifactGate.safePanel = false;
        Destroy(gameObject);
    }

    public void Create(ArtifactGate artifactGate, Canvas artifactCanvas) //создание панельки описания артефакта
    {
        gameObject.transform.SetParent(artifactCanvas.transform, false);
        itemNameText.text = artifactGate.artifact.itemName;
        itemDescText.text = artifactGate.artifact.itemDesc;    
        itemIcon.sprite = artifactGate.artifact.icon;
        itemTypeText.text = Localizator.Localize(artifactGate.artifact.itemType.ToString()) 
            + " (" + Localizator.Localize(artifactGate.artifact.itemSlot.ToString()) + ")"; // -> ItemType (ItemSlot)

        float currentX = artifactGate.transform.localPosition.x; //координата в диапазоне от -960 до 960
        float delta = 480f; 
        float offsetX = currentX / delta;
        float offsetY = 3f;

        transform.position = artifactGate.gameObject.transform.position - new Vector3(offsetX, offsetY, 0); // спускаем панельку вниз и немного вправо
    }

}
