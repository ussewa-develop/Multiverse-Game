using UnityEngine;
using UnityEngine.UI;

public class HeroGate : MonoBehaviour
{
   public HeroSO hero;

    public void Instantiate(HeroSO hero)
    {
        this.hero = hero;
        gameObject.name = hero.entityName;
        GetComponent<Image>().sprite = hero.icon;
    }
}