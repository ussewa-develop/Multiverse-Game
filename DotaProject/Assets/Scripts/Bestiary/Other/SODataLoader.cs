using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SODataLoader
{
    public static HeroSO[] LoadAllHerosSO()
    {
        return LoadAllSO<HeroSO>("Heros/!HeroData");
    }

    public static ArtifactSO[] LoadAllArtSO()
    {
        return LoadAllSO<ArtifactSO>("Artifacts/!ArtifactsData");
    }

    public static Type[] LoadAllSO<Type>(string path) where Type: ScriptableObject 
    {
        Type[] allSO = Resources.LoadAll<Type>(path);
        return allSO;
    }
}
