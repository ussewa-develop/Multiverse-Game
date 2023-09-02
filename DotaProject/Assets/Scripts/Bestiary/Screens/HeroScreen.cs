using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroScreen : EntityScreen
{
    [Header("\t\t\tHero fields")]
    [SerializeField] TextMeshProUGUI talantiesText;
    [SerializeField] Image attributeIcon;
    [SerializeField] TextMeshProUGUI attributeText;

    public override void CreateHero(HeroSO hero)
    {
        attributeText.text = Localizator.Localize(hero.attribute.ToString());
        attributeIcon.sprite = IconLoader.LoadIcon(hero.attribute);
        attributeIcon.SetNativeSize();

        CreateSpells(talantiesText.transform, hero.talanties, contentField, CreateCanvasForSpells(contentField));

        base.CreateHero(hero);
    }
}
