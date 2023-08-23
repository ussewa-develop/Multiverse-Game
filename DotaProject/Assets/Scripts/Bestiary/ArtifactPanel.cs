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
        EventManager.SwitchMenu += Destroy;
        SafePanelEvent += EnableExitButton;
    }

    private void OnDestroy()
    {
        EventManager.SwitchMenu -= Destroy;
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
        Artifact.safePanel = false;
        Destroy(gameObject);
    }

    public void Create(Artifact artifact, Canvas artifactCanvas) //создание панельки описания артефакта
    {
        gameObject.transform.SetParent(artifactCanvas.transform, false);
        itemNameText.text = artifact.GetItemName();
        itemDescText.text = artifact.GetItemDesc();    
        itemIcon.sprite = artifact.GetIconSprite();
        itemTypeText.text = Localizator.Localize(artifact.GetItemType().ToString()) 
            + " (" + Localizator.Localize(artifact.GetItemSlot().ToString()) + ")"; // -> ItemType (ItemSlot)
        
        transform.position = artifact.gameObject.transform.position - new Vector3(-1f, 3f, 0); // спускаем панельку вниз и немного вправо
    }

}
