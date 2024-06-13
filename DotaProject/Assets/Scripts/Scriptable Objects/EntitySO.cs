using System.Collections.Generic;
using UnityEngine;

public enum TypeAttack
{
    Melee,
    Range
}

public enum Race
{
    Robot,
    Undead,
    Animal,
    Humanoid,
    Elemental,
    Other
}

public enum Element
{
    Physical,
    Cryo,
    Darkness,
    Poison,
    Blast,
    Gas,
    Magnetic,
    Psyonic
}
public enum Weapon
{
    Sword,
    Fists,
    Axe,
    Orb,
    Dual_Weapon
}
public enum WeaponType
{
    One_handed_weapon,
    Unarmed,
    Weapon_in_two_hands
}


public class EntitySO : ScriptableObject
{
    [Header("\t\t\tSprites")]
    public Sprite icon;
    public Sprite concept;
    [Header("\t\t\tGeneral")]
    public string entityName;
    public Race race;
    public TypeAttack typeAttack;
    public Weapon weapon;
    public WeaponType weaponType;
    public List<Element> attackElement;
    public SkillSO[] skills; // battle skills
    public SkillSO[] nonCombatSkills; // race/non battle skills
    public SkillSO[] talanties;
}
