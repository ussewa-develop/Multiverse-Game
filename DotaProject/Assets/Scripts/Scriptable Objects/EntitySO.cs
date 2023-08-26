using UnityEngine;

public enum TypeAttack
{
    Melee,
    Range
}
public enum Element
{
    Physical,
    Slash,
    Cryo,
    Darkness,
    Poison
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
    public Element generalElement;
    public TypeAttack typeAttack;
    public Weapon weapon;
    public WeaponType weaponType;
    public Element attackElement;
    public SkillSO[] skills; // battle skills
    public SkillSO[] nonCombatSkills; // race/non battle skills
}
