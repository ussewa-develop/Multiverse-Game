using Unity.Burst.Intrinsics;
using UnityEngine;

public class ArtifactGatesScreen : GatesScreen
{
    [SerializeField] ArtifactGroup artifactGroupPrefab;
    [SerializeField] Canvas canvasForPanel;
    [SerializeField] RectTransform scrollView;
    new void Start()
    {
        LoadAllArtSO();
        base.Start();
    }

    private void LoadAllArtSO()
    {
        var allSO = SODataLoader.LoadAllArtGroupSO();
        foreach (var item in allSO)
        {
            ArtifactGroup artGroup = Instantiate(artifactGroupPrefab, transform).GetComponent<ArtifactGroup>();
            artGroup.Initialize(item, canvasForPanel, scrollView);
        }
        /*
        var allSO = SODataLoader.LoadAllArtGroupSO();
        foreach (var art in allSO)
        {
            
            ArtifactGate artGate = Instantiate(artifactIconPrefab, transform).GetComponent<ArtifactGate>();
            artGate.Initialize(art, canvasForPanel, scrollView);
            
        }
        */
    }

}
