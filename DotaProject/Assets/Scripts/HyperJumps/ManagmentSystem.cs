
using UnityEngine;

public class ManagmentSystem : MonoBehaviour
{
    [SerializeField] GameObject _mainTittleCanvas;
    [SerializeField] GameObject _hyperJumpCanvas;
    [SerializeField] JumpScreen _hyperJumpScreen;

    private void Start()
    {
        _mainTittleCanvas.SetActive(true);
        _hyperJumpScreen.Initialize();
    }
}
