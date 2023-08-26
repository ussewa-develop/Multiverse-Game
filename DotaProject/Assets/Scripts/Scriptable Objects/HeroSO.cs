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
}
