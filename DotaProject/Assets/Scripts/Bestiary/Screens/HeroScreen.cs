using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroScreen : EntityScreen
{
    [SerializeField] Image attributeIcon;
    [SerializeField] TextMeshProUGUI attributeText;

    public override void CreateHero(HeroSO hero)
    {
        attributeText.text = Localizator.Localize(hero.attribute.ToString());
        attributeIcon.sprite = IconLoader.LoadIcon(hero.attribute);
        attributeIcon.SetNativeSize();

        base.CreateHero(hero);
    }
}
