using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpell
{
    public string GetName();
    public string GetDescription();
    public Sprite GetIcon();
}
