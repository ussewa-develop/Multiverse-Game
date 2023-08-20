using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;
#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
public class WikiSkill : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("\t\t\tGENERAL")]
    [SerializeField] protected string nameSkill;
    [SerializeField,TextArea] protected string descSkill;
    [SerializeField] protected Sprite iconSkill;
    [SerializeField] protected SkillType skillType;

    [Header("")]
    [Header("\t\t\tOTHER")]
    [SerializeField, Tooltip("��� ��������� �����������, ���� ������������ ���� ����������� �� ������ �����������?")]
    public bool IsHasSomeSkills = false;
    [HideInInspector] public List<WikiSkill> otherSkills;

    [SerializeField, Tooltip("����������� ������� ��������?")]
    public bool IsHasSummons = false;
    [HideInInspector] public List<Summon> summon;

    [SerializeField, Tooltip("����������� ������� ����?")]
    public bool IsDamaging = false;
    [HideInInspector] public Entity.Element damageType;
    [HideInInspector] private Sprite damageTypeIcon;

    [SerializeField,Tooltip("������������� ������ ��� �������")] SkillPanel panelPrefab;

    //another
    private EntityScreen heroScreen;
    bool THIS_SKILL_ICON = false;
    static SkillPanel panel;
    [HideInInspector] public Canvas canvasForSkillPanel;

    public enum SkillType
    {
        Passive,
        Unit_Target,
        No_Target,
        Target_Area,
        Point_Target
    }

    private void Awake()
    {
        if(otherSkills.Count > 0)
        {
            IsHasSomeSkills = true;
        }
    }

    private void Start()
    {
        if(!ThisEntityOrArtifact())
        {
            EventManager.SwitchMenu += Destroy;
        }
        if (panelPrefab != null)
        {
            THIS_SKILL_ICON = true;
        }
    }

    public void ClickButton()
    {
        if (heroScreen == null)
        {
            heroScreen = FindObjectOfType<EntityScreen>();
        }
        if (IsHasSomeSkills)
        {
            CreateOtherSpells(otherSkills);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (THIS_SKILL_ICON)
        {
            CreatePanel();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (THIS_SKILL_ICON)
        {
            DestroyPanel();
        }
    }

    public void CreateOtherSpells(List<WikiSkill> otherSkills)
    {
        int indexOfSkill = 0;

        foreach (var skill in otherSkills)
        {
            Image gate;
            int deltaForX = 170 * indexOfSkill;
            //
            // ������ ������ ����� � ���������� ��� ������ ��������
            //
            gate = Instantiate(heroScreen.iconAbillityPrefab, gameObject.transform);
            gate.rectTransform.SetParent(gameObject.transform.parent, false);
            gate.GetComponent<WikiSkill>().SetSkill(skill);
            gate.GetComponent<WikiSkill>().canvasForSkillPanel = canvasForSkillPanel;
            gate.sprite = gate.GetComponent<WikiSkill>().GetIcon();
            //
            // ���� ����� ������� ��������� ������ - ��� ��� ������������� �� ����� "�������� ������ �������"
            // ��� �� ���������� ������� ������ ����������� ������ �� �������: ���������� ���� ������ + (170 * ����� ������), ��� 170 - ���������
            //
            if (otherSkills.Count > 1)
            {
                gate.transform.localPosition = gameObject.transform.localPosition + new Vector3(deltaForX, 0, 0);
                EventManager.DestroyOtherSkills += gate.GetComponent<WikiSkill>().Destroy;
            }
            //
            // ���� ����� �������������� �� ���������, �� �������� ����� �������� ������ �������
            // ���� ����� �������� ���� �����, �� ����� ������ �� ����� ������
            // return ��������� ����, ������ ��� ������ ��� �� ������ ����������
            //
            else
            {
                gate.transform.localPosition = gameObject.transform.localPosition;
                EventManager.OnDestroyOtherSkills();
                return;
            }
            indexOfSkill++;
        }
        //����� ����� ������� �����, ������� ������ ������/������ ������
        Destroy(gameObject);
    }


    public void CreatePanel()
    {
        DestroyPanel();
        panel = Instantiate(panelPrefab);
        panel.SetSkillInPanel(this, canvasForSkillPanel, 3.5f);
    }

    public void DestroyPanel()
    {
        if (panel != null)
        {
            panel.Destroy();
        }
    }

    #region Getters
    public string GetDescription()
    {
        return descSkill;
    }

    public Sprite GetIcon()
    {
        return iconSkill;
    }

    public string GetName()
    {
        return nameSkill;
    }

    public SkillType GetSkillType()
    {
        return skillType;
    }

    public List<WikiSkill> GetListOtherSkills()
    {
        return otherSkills;
    }


    public bool GetBool_IsHasSomeSkills()
    {
        return IsHasSomeSkills;
    }

    public bool GetBool_IsHasSummons()
    {
        return IsHasSummons;
    }

    public List<Summon> GetListSummons()
    {
        return summon;
    }

    public bool GetBool_IsDamaging()
    {
        return IsDamaging;
    }

    public Entity.Element GetDamageType()
    {
        return damageType;
    }

    public Sprite GetDamageTypeIcon()
    {
        return damageTypeIcon;
    }

    public WikiSkill GetSkill()
    {
        WikiSkill skill = new WikiSkill();
        skill.nameSkill = nameSkill;
        skill.descSkill = descSkill;
        skill.iconSkill = iconSkill;
        skill.skillType = skillType;

        skill.IsHasSomeSkills = IsHasSomeSkills;
        skill.IsHasSummons = IsHasSummons;
        skill.IsDamaging = IsDamaging;

        skill.otherSkills = otherSkills;
        skill.summon = summon;
        skill.damageType = damageType;
        skill.damageTypeIcon = IconLoader.LoadIcon(damageType);
        return skill;
    }


    #endregion

    #region Setters
    public void SetName(string name)
    {
        nameSkill = name;
    }

    public void SetDesc(string desc)
    {
        descSkill = desc;
    }

    public void SetIcon(Sprite icon)
    {
        iconSkill = icon;
    }

    public void SetSkillType(SkillType skillType)
    {
        this.skillType = skillType;
    }

    public void SetListOtherSkills(List<WikiSkill> listOtherSkills)
    {
        otherSkills = listOtherSkills;
    }

    public void SetBool_IsHasSomeSkills(bool value)
    {
        IsHasSomeSkills = value;
    }

    public void SetBool_IsHasSummons(bool value)
    {
        IsHasSummons = value;
    }

    public void SetListSummons(List<Summon> value)
    {
        summon = value;
    }

    public void SetBool_IsDamaging(bool value)
    {
        IsDamaging = value;
    }

    public void SetDamageType(Entity.Element value)
    {
        damageType = value;
    }

    public void SetDamageTypeIcon(Sprite value)
    {
        damageTypeIcon = value;
    }

    public void SetSkill(WikiSkill skill)
    {
        nameSkill = skill.nameSkill;
        descSkill = skill.descSkill;
        iconSkill = skill.iconSkill;
        skillType = skill.skillType;
        IsHasSomeSkills = skill.IsHasSomeSkills;
        IsHasSummons = skill.IsHasSummons;
        IsDamaging = skill.IsDamaging;
        otherSkills = skill.otherSkills;
        summon = skill.summon;
        damageType = skill.damageType;
        damageTypeIcon = IconLoader.LoadIcon(skill.damageType);
    }

    #endregion

    private bool ThisEntity()
    {
        if(gameObject.GetComponent<Entity>() != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool ThisArtifact()
    {
        if (gameObject.GetComponent<Artifact>() != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool ThisEntityOrArtifact()
    {
        if (ThisArtifact() || ThisEntity())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Destroy()
    {
        if(!ThisEntityOrArtifact())
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if(!ThisEntity())
        {
            EventManager.SwitchMenu -= Destroy;
            EventManager.DestroyOtherSkills -= Destroy;
        }
    }

}
