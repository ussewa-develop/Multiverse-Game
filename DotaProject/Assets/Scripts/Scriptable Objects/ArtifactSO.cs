using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    None,
    Weapon,
    Armour
}
[CreateAssetMenu(fileName = "ArtifactData",menuName = "Create Data/Create Artifact Data")]
public class ArtifactSO : ScriptableObject
{
    [Header("\t\t\tGeneral")]
    public Sprite icon;
    public string itemName;
    [TextArea] public string itemDesc;
    public ItemType itemType;
    public Weapon itemSlot;
    public List<SkillSO> itemSkills; //способности предмета
}
