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

    /*��������� �� ���������
     !!! |---------------------------------------------------------------------------------------------------------------------|
         |��� ������������� ���������, �����:                                                                                  |
         |                                                                                                                     |
         | 1.������� ����� ��� ��������� (���������� �� ���������� 128 �� 128)                                                 |
         | 2.�������� ��� � ����� � �������� ����� �� Multiply                                                                 |
         | 3.��������������� ����� (Edit *** -> � ��� ������� ���)                                                             |
         | 4.������ �� ��� ���� ������ ������� ���� -> Create -> TextMeshPro -> Sprite Asset                                   |
         | 5.������ �� ��������� ���� � ��������� Sprite Character Table (�������� ������ �� ��, ��� ��� ���� � Entity.Element)|
         | 6.� ��� �� ��������� Sprite Glyph Table (Bx = 0; BY = 115.6)                                                        |
         | 7.� ������ ����� "TMP" � ����� TMP Settings                                                                         |
         | 8.������ �� ���� � � Default Sprite Asset �������� �� ������ ��� ���������                                          |
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
