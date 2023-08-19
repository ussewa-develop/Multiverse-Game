using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SummonWiki : EntityScreen
{
    private void Start()
    {
        EventManager.SwitchMenu += Destroy;
    }

    private void Destroy()
    {
        Destroy(gameObject);
        EventManager.SetStandartY();
    }

    private void OnDestroy()
    {
        EventManager.SwitchMenu -= Destroy;
    }
}
