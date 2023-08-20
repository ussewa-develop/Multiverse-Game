using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
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

    private void Start()
    {
        EventManager.SwitchMenu += Destroy;
    }

    private void OnDestroy()
    {
        EventManager.SwitchMenu -= Destroy;
    }

    public void Destroy()
    {
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
