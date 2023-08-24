using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParticleTO : TouchableObject
{
    [SerializeField]ParticleSystem _particleSystem;
    private new void Start()
    {
        base.Start();
        _particleSystem.Stop();
    }

    public ParticleSystem GetParticle()
    {
        return _particleSystem;
    }

    private void OnMouseEnter()
    {
        ChangeState(new ParticleAnimState(this));
    }

    private void OnMouseExit()
    {
        ChangeState(new IdleState());
    }
}
