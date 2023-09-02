using System.Collections.Generic;
using UnityEngine;


public enum SkillType
{
    None,
    Passive,
    Unit_Target,
    No_Target,
    Target_Area,
    Point_Target
}

[CreateAssetMenu(fileName = "SkillData", menuName = "Create Data/Create Entity Data/Create Skill Data")]
public class SkillSO : ScriptableObject
{
    public SkillType skillType;
    public string skillName;
    [TextArea] public string skillDesc;
    public Sprite skillIcon;
    public int cooldown;
    public int manaCost;
    public int actionPointCost;

    [Space]
    [Header("\t\t\tOTHER")]
    [SerializeField, Tooltip("При активации способности, идет переключение этой способности на другую способность?")]
    public bool IsHasSomeSkills = false;
    [HideInInspector] public List<SkillSO> otherSkills;

    [SerializeField, Tooltip("Способность создает суммонов?")]
    public bool IsHasSummons = false;
    [HideInInspector] public List<SummonSO> summon;

    [SerializeField, Tooltip("Способность наносит урон?")]
    public bool IsDamaging = false;
    [HideInInspector] public Element damageType;
}
