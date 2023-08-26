using UnityEngine;

public class ArtifactGatesScreen : GatesScreen
{
    [SerializeField] ArtifactGate artifactIconPrefab;
    new void Start()
    {
        LoadAllArtSO();
        base.Start();
    }

    private void LoadAllArtSO()
    {
        var allSO = SODataLoader.LoadAllArtSO();
        foreach (var art in allSO)
        {
            ArtifactGate artGate = Instantiate(artifactIconPrefab, transform).GetComponent<ArtifactGate>();
            artGate.Instantiate(art);
        }
    }

}
