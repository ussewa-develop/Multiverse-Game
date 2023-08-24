using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimatedTO : TouchableObject
{
    Animator _animator;

    private new void Start()
    {
        base.Start();
        _animator = GetComponent<Animator>();
    }

    public Animator GetAnimator()
    {
        return _animator;
    }

    private void OnMouseEnter()
    {
        ChangeState(new AnimState(this));
    }

    private void OnMouseExit()
    {
        ChangeState(new IdleState());
    }

}
