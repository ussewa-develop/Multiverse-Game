using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Hero;

public abstract class Entity : MonoBehaviour
{
    [Header("\t\t\tGeneral")]
    protected Sprite iconSprite;
    protected Sprite conceptSprite;
    [SerializeField] protected string creatureName;
    [SerializeField] protected Element generalElement;
    [Header("\t\t\tWeapon")]
    [SerializeField] protected TypeAttack typeAttack;
    [SerializeField] protected Weapon weapon;
    [SerializeField] protected WeaponType weaponType;
    [SerializeField] protected Element attackElement;
    [Header("\t\t\tSpells")]
    [SerializeField] public WikiSkill[] skills;
    [SerializeField] public WikiSkill[] nonCombatSkills;

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

    public string GetName()
    {
        return creatureName;
    }

    public Sprite GetIcon()
    {
        return iconSprite;
    }

    public Sprite GetConceptSprite()
    {
        return conceptSprite;
    }

    public Element GetElement()
    {
        return generalElement;
    }

    public TypeAttack GetAttackType()
    {
        return typeAttack;
    }

    public Weapon GetWeapon()
    {
        return weapon;
    }

    public WeaponType GetWeaponType()
    {
        return weaponType;
    }

    public Element GetAttackElement()
    {
        return attackElement;
    }

    public WikiSkill GetSkill(int id)
    {
        return skills[id];
    }
}
