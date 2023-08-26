using UnityEngine;
using UnityEngine.UI;

public class HeroGate : MonoBehaviour
{
   public HeroSO hero;

    public void Instantiate(HeroSO hero)
    {
        this.hero = hero;
        GetComponent<Image>().sprite = hero.icon;
    }
}
