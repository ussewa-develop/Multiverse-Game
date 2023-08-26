using UnityEngine;

public class ParticleMenuObj : MonoBehaviour
{
    [SerializeField]ParticleSystem _particleSystem;

    private void OnMouseEnter()
    {
        _particleSystem.Play();
    }

    private void OnMouseExit()
    {
        _particleSystem.Stop();
    }
}
