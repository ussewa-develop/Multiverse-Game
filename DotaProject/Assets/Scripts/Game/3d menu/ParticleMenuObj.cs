using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
