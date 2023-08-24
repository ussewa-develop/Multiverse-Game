using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimState : State
{
    Animator _animator;
    public AnimState(AnimatedTO obj)
    {
        _animator = obj.GetAnimator();
    }
    public override void Enter()
    {
        base.Enter();
        _animator.SetBool("Open", true);
        _animator.SetBool("Close", false);
    }

    public override void Exit()
    {
        base.Exit();
        _animator.SetBool("Open", false);
        _animator.SetBool("Close", true);
    }
}
