using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperJumpHero : MonoBehaviour
{
    [SerializeField] Animator _mainTitleAnimator;
    [SerializeField] ParticleSystem _portal;
    [SerializeField] 


    public void HyperJumpStart()
    {
        _mainTitleAnimator.SetBool("JumpStart",true);
        _mainTitleAnimator.SetBool("JumpEnd", false);
        _portal.Play();
    }

    public void HyperJumpEnd()
    {
        _mainTitleAnimator.SetBool("JumpStart", false);
        _mainTitleAnimator.SetBool("JumpEnd", true);
        _portal.Stop();
    }
}
