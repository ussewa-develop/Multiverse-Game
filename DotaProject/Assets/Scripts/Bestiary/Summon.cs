using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : Entity
{
    [HideInInspector] public string nameSummoner; //имя суммонера для загрузки спрайтов

    private void Start()
    {
        nameSummoner = gameObject.transform.parent.GetComponent<Hero>().GetName();

        string pathForIcon = "Heros/" + nameSummoner + "/" + creatureName;
        string pathForConcept = pathForIcon + "_concept";
        iconSprite = Resources.Load<Sprite>(pathForIcon);
        conceptSprite = Resources.Load<Sprite>(pathForConcept);
    }
}
