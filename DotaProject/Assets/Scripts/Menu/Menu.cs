using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("Unique name for menu")]
    public string menuName;
    [Header("Camera for screen")]
    public Camera menuCamera;
    [Header("Hide other UI?")]
    public bool hideOtherUI;
}
