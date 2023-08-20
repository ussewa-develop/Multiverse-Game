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

    /*Подсказка по смайликам
     !!! |---------------------------------------------------------------------------------------------------------------------|
         |Для использования смайликов, нужно:                                                                                  |
         |                                                                                                                     |
         | 1.Создать атлас для смайликов (желательно со смайликами 128 на 128)                                                 |
         | 2.Закинуть его в юнити и поменять режим на Multiply                                                                 |
         | 3.Отформатировать атлас (Edit *** -> и там понятно уже)                                                             |
         | 4.Нажать на сам файл правой кнопкой мыши -> Create -> TextMeshPro -> Sprite Asset                                   |
         | 5.Нажать на созданный файл и настроить Sprite Character Table (поменять именна на то, как они есть в Entity.Element)|
         | 6.И так же настроить Sprite Glyph Table (Bx = 0; BY = 115.6)                                                        |
         | 7.В поиске вбить "TMP" и найти TMP Settings                                                                         |
         | 8.Нажать на него и в Default Sprite Asset поменять на только что созданный                                          |
     !!! |---------------------------------------------------------------------------------------------------------------------|
    */

    public static string LoadSmile(Hero.Element element)
    {
        return "<sprite name=" + element.ToString() + "> ";
    }

    public static string LoadSmile(Hero.TypeAttack typeAttack)
    {
        return "<sprite name=" + typeAttack.ToString() + "> ";
    }
}
