using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconLoader : MonoBehaviour
{
    public static Sprite LoadIcon(Entity.Element element)
    {
        return Resources.Load<Sprite>("!Icons/Element/" + element.ToString());
    }

    public static Sprite LoadIcon(Entity.TypeAttack typeAttack)
    {
        return Resources.Load<Sprite>("!Icons/Attack Type/" + typeAttack.ToString());
    }

    public static Sprite LoadIcon(Entity.WeaponType typeWeapon)
    {
        return Resources.Load<Sprite>("!Icons/Weapon Type/" + typeWeapon.ToString());
    }

    public static Sprite LoadIcon(Entity.Weapon weapon)
    {
        return Resources.Load<Sprite>("!Icons/Attack Icons/" + weapon.ToString());
    }

    public static Sprite LoadIcon(Hero.Attribute attribute)
    {
        return Resources.Load<Sprite>("!Icons/Attributes/" + attribute.ToString());
    }
}
