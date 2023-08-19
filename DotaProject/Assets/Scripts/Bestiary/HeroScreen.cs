using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroScreen : EntityScreen
{
    [SerializeField] Image attributeIcon;
    [SerializeField] TextMeshProUGUI attributeText;

    public override void CreateHero(Hero hero)
    {
        attributeText.text = Localizator.Localize(hero.GetAttribute().ToString());
        attributeIcon.sprite = IconLoader.LoadIcon(hero.GetAttribute());
        attributeIcon.SetNativeSize();

        base.CreateHero(hero);
    }
}
