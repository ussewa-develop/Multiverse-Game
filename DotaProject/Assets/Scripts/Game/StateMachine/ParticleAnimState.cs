using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAnimState : State
{
    ParticleSystem _particleSystem;
    public ParticleAnimState(ParticleTO obj)
    {
        _particleSystem = obj.GetParticle();
    }
    public override void Enter()
    {
        base.Enter();
        _particleSystem.Play();
    }

    public override void Exit()
    {
        base.Exit();
        _particleSystem.Stop();
    }
}
