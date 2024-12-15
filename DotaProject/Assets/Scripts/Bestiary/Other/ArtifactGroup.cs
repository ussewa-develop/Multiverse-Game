using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactGroup : MonoBehaviour
{
    public ArtifactGate[] artGates = new ArtifactGate[3];

    public void Initialize(ArtifactGroupSO artGroup, Canvas canvas, RectTransform scrollView)
    {
        for(int i = 0; i < artGates.Length; i++)
        {
            artGates[i].Initialize(artGroup.artifactsGroup[i], canvas, scrollView);
        }
    }
}
