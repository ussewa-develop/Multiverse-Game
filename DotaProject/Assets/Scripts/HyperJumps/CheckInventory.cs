using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInventory : MonoBehaviour
{
    private HeroSO[] heros;
    private List<HeroGate> heroGates;
    private void Start()
    {
        heros = SODataLoader.LoadAllHerosSO();
    }

}
