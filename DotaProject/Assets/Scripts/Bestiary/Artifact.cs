using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Artifact : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("General")]
    [SerializeField] Sprite iconSprite;
    [SerializeField] string itemName;
    [SerializeField, TextArea] string itemDesc;
    [SerializeField] ItemType itemType;
    [SerializeField] ItemSlot itemSlot;
    [SerializeField] List<WikiSkill> itemSkills;
    [SerializeField] ArtifactPanel artifactPrefab;

    static ArtifactPanel panel;
    [SerializeField] Canvas canvasForArtDesc;
    static bool safePanel = false;

    public enum ItemType 
    {
        None,
        Weapon,
        Armour
    }

    public enum ItemSlot
    {
        Sword
    }

    private void Start()
    {
        gameObject.name = itemName;
    }

    #region Getters

    public Sprite GetIconSprite()
    {
        return iconSprite;
    }

    public string GetItemName()
    {
        return itemName;
    }

    public string GetItemDesc()
    {
        return itemDesc;
    }

    public ItemType GetItemType()
    {
        return itemType;
    }

    public ItemSlot GetItemSlot()
    {
        return itemSlot;
    }

    public List<WikiSkill> GetItemSkills()
    {
        return itemSkills;
    }

    #endregion

    #region Setters

    public void SetIconSprite(Sprite value)
    {
        iconSprite = value;
    }

    public void SetItemName(string value)
    {
        itemName = value;
    }

    public void SetItemDesc(string value) 
    { 
        itemDesc = value;
    }

    public void SetItemType(ItemType type)
    {
        itemType = type;
    }

    public void SetItemSlot(ItemSlot slot)
    {
        itemSlot = slot;
    }

    public void SetItemSkills(List<WikiSkill> skillList)
    {
        itemSkills = new List<WikiSkill>();
        itemSkills = skillList;
    }

    #endregion

    public void ClickOn()
    {
        safePanel = !safePanel;
    }

    public void CreatePanel()
    {
        DestroyPanel();
        panel = Instantiate(artifactPrefab);
        panel.SetItemDesc(GetComponent<Artifact>(), canvasForArtDesc);
        foreach (var skill in itemSkills)
        {
            panel.contentField.sizeDelta += new Vector2(0f,500f);

            Canvas canvas = Instantiate(panel.canvasPrefab, panel.transform);
            canvas.sortingOrder = 2;


            SkillPanel skillPanel = Instantiate(panel.skillPanelPrefab);

            skillPanel.transform.position = Vector2.zero;
            skillPanel.SetSkillInPanel(skill,canvas,panel.transform,2.6f); //yOffset = 4.8f

            canvas.transform.SetParent(panel.contentField,false);

            skillPanel.transform.localPosition += new Vector3(5f,0);
        }

    }

    public void DestroyPanel()
    {
        if (panel != null)
        {
            panel.Destroy();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!safePanel)
        {
            CreatePanel();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!safePanel)
        {
            DestroyPanel();
        }
    }
}
