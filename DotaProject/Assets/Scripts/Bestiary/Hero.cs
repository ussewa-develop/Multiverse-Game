using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hero : Entity
{
    [Header("\t\tAttribute/Universe")]
    [SerializeField] Attribute attribute;
    [SerializeField] Multiverse multiverse;

    private void Start()
    {
        string pathForIcon = "Heros/" + creatureName + "/" + creatureName;
        string pathForConcept = pathForIcon + "_concept";
        iconSprite = Resources.Load<Sprite>(pathForIcon);
        conceptSprite = Resources.Load<Sprite>(pathForConcept);
    }

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

    private void Awake()
    {
        gameObject.name = creatureName;
    }

    public Attribute GetAttribute()
    {
        return attribute;
    }
    
    public Multiverse GetMultiverse()
    {
        return multiverse;
    }
}
