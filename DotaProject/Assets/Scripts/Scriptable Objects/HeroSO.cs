using UnityEngine;

public enum Attribute
{
    Strength,
    Agillity,
    Intelligence,
    Universal
}
public enum Multiverse
{
    Dota_2
}
[CreateAssetMenu(fileName = "HeroData",menuName = "Create Data/Create Entity Data/Create Hero Data")]
public class HeroSO : EntitySO
{
    public Attribute attribute;
    public Multiverse multiverse;
    [Header("\t\t\tPlayer Data")]
    [SerializeField] private int constLevel;
    public int ConstLevel
    {
        get { return constLevel; }
        set
        {
            if (value > 0 && constLevel < 6)
            {
                constLevel = value;
            }
        }
    }
}
