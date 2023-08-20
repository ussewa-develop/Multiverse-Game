using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Artifact : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("\t\t\tGeneral")]
    [SerializeField] Sprite iconSprite;
    [SerializeField] string itemName;
    [SerializeField, TextArea] string itemDesc;
    [SerializeField] ItemType itemType;
    [SerializeField] Entity.Weapon itemSlot;
    [SerializeField] List<WikiSkill> itemSkills; //способности предмета
    [SerializeField] ArtifactPanel artifactPrefab;

    static ArtifactPanel panel;
    [SerializeField] Canvas canvasForArtDesc;
    static public bool safePanel = false; //переменная для сохранения панельки при нажатии на артефакт

    public enum ItemType 
    {
        None,
        Weapon,
        Armour
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

    public Entity.Weapon GetItemSlot()
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

    public void SetItemSlot(Entity.Weapon slot)
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
        ArtifactPanel.OnChangeSafePanel();
    }

    public void CreatePanel()
    {
        Vector3 posPrevSkill = Vector3.zero;//переменная для координат панельки предыдущего скилла
        float deltaY = 7f; //
        bool isFirstSkill = true;

        DestroyPanel();
        panel = Instantiate(artifactPrefab);
        panel.Create(GetComponent<Artifact>(), canvasForArtDesc);
        foreach (var skill in itemSkills) //перебираем массив скиллов
        {
            if (isFirstSkill)//проверяем на первый скилл в массиве
            {
                //ставим коорды самого контент филда и сразу расширяем контентфилд на количество скиллов
                //
                posPrevSkill = panel.contentField.transform.position; 
                panel.contentField.sizeDelta += new Vector2(0f, 600f * itemSkills.Count);
                //
                isFirstSkill = false;
            }
            else //если это не первый скилл, уменьшаем разрез между ними
            {
                deltaY = 5.5f;
            }
            
            SkillPanel skillPanel = Instantiate(panel.skillPanelPrefab, panel.contentField); // создаем панельку способности
            skillPanel.SetSkillInPanel(skill,panel.transform, 0f); // устанавливаем значения в панельку для скилла
            skillPanel.background.SetActive(false);

            skillPanel.transform.position = posPrevSkill - new Vector3(0f, deltaY, 0f);

            posPrevSkill = skillPanel.transform.position;
            //skillPanel.transform.localPosition = new Vector3(0f,-775f*counterOfSkills,0f);
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
