using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JumpScreen : MonoBehaviour
{
    [SerializeField] Image heroConcept;
    [SerializeField] TextMeshProUGUI heroName;

    public void Initialize()
    {
        HyperJumpHero.setHero += SetHero;
    }

    private void OnDestroy()
    {
        HyperJumpHero.setHero -= SetHero;
    }

    private void SetHero(HeroSO hero)
    {
        heroName.text = hero.entityName;
        heroConcept.sprite = hero.concept;
        hero.ConstLevel += 1;
    }
}
