using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ArtifactGroupData", menuName = "Create Data/Create Artifact Group Data")]
public class ArtifactGroupSO : ScriptableObject
{
    [Header("\t\t\tGeneral")]
    public ArtifactSO[] artifactsGroup = new ArtifactSO[3];
}
